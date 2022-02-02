using Einstein.Core.Models;
using Einstein.Core.Repositories;

namespace Einstein.Core.Services
{
    public class AlunoService : ServiceBase
    {
        private readonly IAlunoRepository _repository;        

        public AlunoService(
            IAlunoRepository repository,            
            INotificador notificador            
            ) : base(notificador)
        {
            _repository = repository;            
        }

        public async Task<IEnumerable<Aluno>> Listar()
        {
            return await _repository.GetAll();
        }
        public async Task Adicionar(Aluno aluno)
        {
            await _repository.Adicionar(aluno);
        }
        public async Task Atualizar(Aluno aluno)
        {
            
        }
    }
}
