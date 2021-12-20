using Einstein.Core.Enums;
using Einstein.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public UsuarioRepository(UserManager<IdentityUser<Guid>> userManager) => _userManager = userManager;

        public async Task<IdentityResult> Adicionar(IdentityUser<Guid> user, string password) =>
            await _userManager.CreateAsync(user, password);

        public async Task<IdentityResult> VincularPerfil(IdentityUser<Guid> user, string newRole, string? oldRole = null)
        {
            if (oldRole is not null)
                await _userManager.RemoveFromRoleAsync(user, oldRole);

            return await _userManager.AddToRoleAsync(user, newRole);
        }

        public async Task<IdentityResult> Atualizar(IdentityUser<Guid> user) =>
            await _userManager.UpdateAsync(user);

        public async Task<IEnumerable<IdentityUser<Guid>>> Obter() =>
            await _userManager.Users.ToListAsync();

        public async Task<IEnumerable<IdentityUser<Guid>>> ObterPorRole(Roles role) =>
            await _userManager.GetUsersInRoleAsync(role.ToString());

        public async Task<IdentityUser<Guid>> ObterPorEmail(string email) => await _userManager.FindByEmailAsync(email);

        public async Task<IEnumerable<string>> ObterRole(IdentityUser<Guid> user) => await _userManager.GetRolesAsync(user);

        public async Task<IdentityUser<Guid>> ObterPorId(Guid id) => await _userManager.FindByIdAsync(id.ToString());

        public async Task<IdentityResult> Remover(IdentityUser<Guid> user) =>
            await _userManager.DeleteAsync(user);

        public async Task<IdentityResult> AlterarSenha(IdentityUser<Guid> user, string senhaAtual, string novaSenha) =>
            await _userManager.ChangePasswordAsync(user, senhaAtual, novaSenha);

        public async Task<bool> UsuarioExiste(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            return user != null;
        }
    }
}
