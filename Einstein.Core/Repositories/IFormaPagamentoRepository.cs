using Einstein.Core.Helpers;

namespace Einstein.Core.Repositories
{
    public interface IFormaPagamentoRepository
    {
        Task<IEnumerable<ComboBase<short>>> ObterCombo();
    }
}
