using Einstein.Core.Models;
using Einstein.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Einstein.Core.Services
{
    public class AlunoService : ServiceBase
    {
        private readonly IAlunoRepository _repository;
        private readonly UsuarioService _usuarioService;

        public AlunoService(
            IAlunoRepository repository,
            UsuarioService usuarioService,
            INotificador notificador,
            IUnitOfWork uow
            ) : base(notificador, uow)
        {
            _repository = repository;
            _usuarioService = usuarioService;
        }

        public async Task Adicionar(object obj)
        {
            var userId = await _usuarioService.Adicionar(new IdentityUser<Guid>
            {

            }, "");

            if (!userId.HasValue)
            {
                Notificar("");
                return;
            }

            await _repository.Add(new Aluno
            {
                UserId = userId.Value,
            });

            await Commit();
        }
    }
}
