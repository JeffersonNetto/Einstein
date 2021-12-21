using Einstein.Core.Helpers;
using Einstein.Core.QueryServices;
using Einstein.Core.QueryServices.Models;
using Einstein.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Einstein.Api.Controllers
{
    public class MovimentoFinanceiroController : MainController
    {
        private readonly IMovimentoFinanceiroQueryService _queryService;

        public MovimentoFinanceiroController(
            IMovimentoFinanceiroQueryService queryService,
            INotificador notificador, 
            IUser appUser) : base(notificador, appUser)
        {
            _queryService = queryService;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar([FromQuery] FiltroMovimentoFinanceiro filtro)
        {
            var response = await _queryService.Listar(filtro);            

            return CustomResponse(response);
        }
    }
}
