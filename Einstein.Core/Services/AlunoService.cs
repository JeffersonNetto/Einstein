using Einstein.Core.Enums;
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

        public async Task Adicionar(Aluno aluno)
        {
            var userId = await _usuarioService.Adicionar(new IdentityUser<Guid>
            {
                Email = aluno.Email,
                PhoneNumber = aluno.Celular,
                UserName = aluno.CPF,
            }, "123456", nameof(Roles.Aluno));

            if (!userId.HasValue)
            {
                Notificar("Não foi possível realizar o cadastro do aluno");
                return;
            }

            aluno.UserId = userId.Value;

            await _repository.Add(aluno);

            await Commit();
        }
    }
}
