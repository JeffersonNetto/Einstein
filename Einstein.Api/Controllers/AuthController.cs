using Einstein.Core.Helpers;
using Einstein.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Einstein.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public AuthController(
            INotificador notificador,
            UserManager<IdentityUser<Guid>> userManager,
            ILogger<AuthController> logger,
            SignInManager<IdentityUser<Guid>> signInManager,
            IOptions<JwtSettings> jwtSettings,
            IUser user
            ) : base(notificador, user)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<LoginResponseViewModel>> Login(LoginUserViewModel loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);

            if (user == null)
            {
                NotificarErro("Usuário ou Senha incorretos");
                return CustomResponse();
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginUser.Password, false, true);

            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            if (!result.Succeeded)
            {
                NotificarErro("Usuário ou Senha incorretos");
                return CustomResponse();
            }

            _logger.LogInformation("Usuario " + loginUser.Email + " logado com sucesso");

            return CustomResponse(await GenerateToken(user));
        }

        private async Task<LoginResponseViewModel> GenerateToken(IdentityUser<Guid> user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
                claims.Add(new Claim("role", userRole));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var encodedAccessToken = GetEncodedToken(TokenType.Access, identityClaims);
            var encodedRefreshToken = GetEncodedToken(TokenType.Refresh, identityClaims);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedAccessToken,
                RefreshToken = encodedRefreshToken,
                ExpiresIn = TimeSpan.FromHours(_jwtSettings.Expires).TotalSeconds,
                User = new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private enum TokenType
        {
            Access = 1,
            Refresh = 2,
        }

        private string GetEncodedToken(TokenType tokenType, ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(tokenType == TokenType.Access ? _jwtSettings.Expires : _jwtSettings.Expires * 8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            });

            return tokenHandler.WriteToken(token);
        }
    }

    public record LoginUserViewModel
    {
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;
    }

    public record UserViewModel
    {
        public Guid Id { get; init; }
        public string Email { get; init; } = default!;
        public string UserName { get; init; } = default!;
        public IEnumerable<ClaimViewModel>? Claims { get; init; }
    }

    public record LoginResponseViewModel
    {
        public string AccessToken { get; init; } = default!;
        public string RefreshToken { get; init; } = default!;
        public double ExpiresIn { get; init; }
        public UserViewModel User { get; init; } = default!;
    }

    public record ClaimViewModel
    {
        public string Value { get; init; } = default!;
        public string Type { get; init; } = default!;
    }
}
