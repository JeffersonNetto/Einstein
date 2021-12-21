using Einstein.Core.Helpers;
using Einstein.Core.Repositories;
using Einstein.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Einstein.Api.Controllers
{
    public class FormaPagamentoController : MainController
    {
        private readonly IFormaPagamentoRepository _repository;

        public FormaPagamentoController(
            IFormaPagamentoRepository repository,
            INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _repository = repository;
        }

        [HttpGet("Combo")]
        public async Task<IActionResult> ObterCombo()
        {
            var response = await _repository.ObterCombo();

            return CustomResponse(response);
        }
    }
}
