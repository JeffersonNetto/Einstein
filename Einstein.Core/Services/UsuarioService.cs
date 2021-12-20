using Einstein.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace Einstein.Core.Services
{
    public class UsuarioService : ServiceBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(
            INotificador notificador,
            IUnitOfWork uow,
            IUsuarioRepository usuarioRepository) : base(notificador, uow)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Guid?> Adicionar(IdentityUser<Guid> obj, string password, string role)
        {
            var result = await _usuarioRepository.Adicionar(obj, password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return null;
            }

            var user = await _usuarioRepository.ObterPorEmail(obj.Email);

            await _usuarioRepository.VincularPerfil(user, role);

            return user.Id;
        }

        public async Task<bool> Atualizar(IdentityUser<Guid> model, string role)
        {
            var user = await _usuarioRepository.ObterPorId(model.Id);

            if (user == null)
            {
                Notificar("Usuário não existe na base de dados");
                return false;
            }

            await _usuarioRepository.VincularPerfil(user, role);

            foreach (PropertyInfo property in typeof(IdentityUser<Guid>).GetProperties())
                property.SetValue(user, property.GetValue(model, null), null);

            var result = await _usuarioRepository.Atualizar(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return false;
            }

            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            var user = await _usuarioRepository.ObterPorId(id);

            if (user == null)
            {
                Notificar("Usuário não existe na base de dados");
                return false;
            }

            var result = await _usuarioRepository.Remover(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return false;
            }

            return true;
        }

        public async Task<bool> AlterarSenha(Guid id, AlterarSenhaViewModel model)
        {
            var user = await _usuarioRepository.ObterPorId(id);

            if (user == null)
            {
                Notificar("Usuário não existe na base de dados");
                return false;
            }

            var result = await _usuarioRepository.AlterarSenha(user, model.SenhaAtual!, model.NovaSenha!);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return false;
            }

            return true;
        }

        public async Task<string> ObterRole(Guid id)
        {
            var user = await _usuarioRepository.ObterPorId(id);

            if (user == null)
                Notificar("Usuário não existe na base de dados");

            var roles = await _usuarioRepository.ObterRole(user!);

            return roles.First();
        }

        public async Task<bool> UsuarioExiste(Guid id)
        {
            return await _usuarioRepository.UsuarioExiste(id);
        }
    }

    public record AlterarSenhaViewModel
    {
        public string? SenhaAtual { get; init; }
        public string? NovaSenha { get; init; }
    }
}
