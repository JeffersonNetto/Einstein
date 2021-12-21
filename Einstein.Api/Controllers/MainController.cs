using Einstein.Core.Helpers;
using Einstein.Core.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Einstein.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        protected readonly IUser AppUser;

        protected Guid? UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(
            INotificador notificador,
            IUser appUser
            )
        {
            _notificador = notificador;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected void NotificarErro(string mensagem) => _notificador.Handle(new Notificacao(mensagem));
        protected bool OperacaoValida() => !_notificador.TemNotificacao();

        protected ActionResult CustomResponse(object? dados = null, int? successStatusCode = StatusCodes.Status200OK, int? errorStatusCode = StatusCodes.Status400BadRequest)
        {
            if (!OperacaoValida())
            {
                var obj = new { Erros = _notificador.ObterNotificacoes().Select(n => n.Mensagem) };

                return errorStatusCode switch
                {
                    StatusCodes.Status422UnprocessableEntity => UnprocessableEntity(obj),
                    StatusCodes.Status404NotFound => NotFound(obj),
                    StatusCodes.Status403Forbidden => Forbid(),
                    _ => BadRequest(obj),
                };
            }
            
            return successStatusCode switch
            {
                StatusCodes.Status201Created => Created("", new { Dados = dados }),
                StatusCodes.Status204NoContent => NoContent(),
                _ => Ok(new { Dados = dados }),
            };
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }
    }
}
