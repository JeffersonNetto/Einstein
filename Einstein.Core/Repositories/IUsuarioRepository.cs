using Einstein.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Einstein.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IdentityResult> Adicionar(IdentityUser<Guid> user, string password);
        Task<IdentityResult> AlterarSenha(IdentityUser<Guid> user, string senhaAtual, string novaSenha);
        Task<IdentityResult> Atualizar(IdentityUser<Guid> user);
        Task<IEnumerable<IdentityUser<Guid>>> Obter();
        Task<IdentityUser<Guid>> ObterPorEmail(string email);
        Task<IdentityUser<Guid>> ObterPorId(Guid id);
        Task<IEnumerable<IdentityUser<Guid>>> ObterPorRole(Roles role);
        Task<IEnumerable<string>> ObterRole(IdentityUser<Guid> user);
        Task<IdentityResult> Remover(IdentityUser<Guid> user);
        Task<bool> UsuarioExiste(Guid id);
        Task<IdentityResult> VincularPerfil(IdentityUser<Guid> user, string newRole, string? oldRole = null);
    }
}
