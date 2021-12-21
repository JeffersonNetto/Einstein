using Einstein.Core.Helpers;
using Einstein.Core.Models;
using Einstein.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Infra.Repositories
{
    public class FormaPagamentoRepository : RepositoryBase<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<ComboBase<short>>> ObterCombo()
        {
            return await _context.FormaPagamento
                                 .AsNoTracking()
                                 .Select(x => new ComboBase<short>
                                 {
                                     Text = x.Descricao,
                                     Value = x.Id,
                                 }).ToListAsync();
        }
    }
}
