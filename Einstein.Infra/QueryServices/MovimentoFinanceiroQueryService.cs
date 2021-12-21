using Einstein.Core.Models;
using Einstein.Core.QueryServices;
using Einstein.Core.QueryServices.Models;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Infra.QueryServices
{
    public class MovimentoFinanceiroQueryService : IMovimentoFinanceiroQueryService
    {
        private readonly ApplicationDbContext _context;

        public MovimentoFinanceiroQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovimentoFinanceiro>> Listar(FiltroMovimentoFinanceiro filtro)
        {
            var query = _context.MovimentoFinanceiro.AsQueryable();

            if (filtro.FormaPagamentoId.HasValue)
            {
                query = query.Where(x => x.FormaPagamentoId == filtro.FormaPagamentoId);
            }

            if (filtro.TipoMovimentoFinanceiro.HasValue)
            {
                query = query.Where(x => x.TipoMovimentoFinanceiro == filtro.TipoMovimentoFinanceiro);
            }

            if (filtro.DataMovimentoDe.HasValue)
            {
                query = query.Where(x => x.DataHora.Date >= filtro.DataMovimentoDe);
            }

            if (filtro.DataMovimentoAte.HasValue)
            {
                query = query.Where(x => x.DataHora.Date <= filtro.DataMovimentoAte);
            }

            if (filtro.ValorMovimentoDe.HasValue)
            {
                query = query.Where(x => x.ValorTotal >= filtro.ValorMovimentoDe);
            }

            if (filtro.ValorMovimentoAte.HasValue)
            {
                query = query.Where(x => x.ValorTotal <= filtro.ValorMovimentoAte);
            }

            return await query.ToListAsync();
        }
    }
}
