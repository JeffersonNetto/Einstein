using Einstein.Core.Models;
using Einstein.Core.QueryServices.Models;

namespace Einstein.Core.QueryServices
{
    public interface IMovimentoFinanceiroQueryService
    {
        Task<IEnumerable<MovimentoFinanceiro>> Listar(FiltroMovimentoFinanceiro filtro);
    }
}
