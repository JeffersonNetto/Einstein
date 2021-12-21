using Einstein.Core.Enums;
using Einstein.Core.Models;
using Einstein.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Einstein.Core.Services
{
    public class ProfessorService : ServiceBase
    {
        private readonly IProfessorRepository _repository;
        private readonly UsuarioService _usuarioService;

        public ProfessorService(
            IProfessorRepository repository,
            INotificador notificador, IUnitOfWork uow, 
            UsuarioService usuarioService) : base(notificador, uow)
        {
            _repository = repository;
            _usuarioService = usuarioService;
        }

        public async Task Adicionar(Professor professor)
        {
            var userId = await _usuarioService.Adicionar(new IdentityUser<Guid>
            {
                Email = professor.Email,
                PhoneNumber = professor.Celular,
                UserName = professor.CPF,
            }, "123456", nameof(Roles.Professor));

            if (!userId.HasValue)
            {
                Notificar("Não foi possível realizar o cadastro do professor");
                return;
            }

            professor.UserId = userId.Value;

            await _repository.Add(professor);

            await Commit();
        }

        public async Task Atualizar(Professor obj)
        {
            var professor = await _repository.GetById(obj.Id);

            if (professor is null)
            {
                Notificar("Professor não encontrado no sistema");
                return;
            }                

            professor.Nome += " (alterado)";
            
            _repository.Update(professor);

            await Commit();
        }
    }
}
