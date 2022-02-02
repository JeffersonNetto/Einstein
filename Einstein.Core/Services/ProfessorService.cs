using Einstein.Core.Models;
using Einstein.Core.Repositories;

namespace Einstein.Core.Services
{
    public class ProfessorService : ServiceBase
    {
        private readonly IProfessorRepository _repository;
        
        public ProfessorService(
            IProfessorRepository repository,
            INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }

        public async Task Adicionar(Professor professor)
        {
            await Task.Delay(1000);
        }
    }
}
