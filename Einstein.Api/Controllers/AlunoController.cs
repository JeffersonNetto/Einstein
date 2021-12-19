using Einstein.Core.Helpers;
using Einstein.Core.Models;
using Einstein.Core.Repositories;
using Einstein.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Einstein.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : MainController
    {
        private readonly IAlunoRepository _repository;
        private readonly AlunoService _service;

        public AlunoController(
            INotificador notificador,
            IUser appUser, 
            IAlunoRepository repository, 
            AlunoService service) : base(notificador, appUser)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Aluno>> Listar()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<Aluno?> Obter(Guid id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(object obj)
        {
            await _service.Adicionar(obj);

            return CustomResponse(obj);
        }
    }
}
