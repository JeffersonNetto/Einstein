using Einstein.Core.Models;
using Einstein.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Einstein.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Aluno>> Listar([FromServices] IAlunoRepository repository)
        {
            return await repository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<Aluno?> Obter(Guid id, [FromServices] IAlunoRepository repository)
        {
            return await repository.GetById(id);
        }
    }
}
