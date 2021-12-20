using Bogus;
using Bogus.Extensions.Brazil;
using Einstein.Core.Enums;
using Einstein.Core.Helpers;
using Einstein.Core.Models;
using Einstein.Core.Repositories;
using Einstein.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Einstein.Api.Controllers
{
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
        public async Task<IActionResult> Adicionar(Aluno obj)
        {
            obj = new Faker<Aluno>("pt_BR")
                .RuleFor(x => x.Nome, f => f.Person.FirstName)
                .RuleFor(x => x.Sobrenome, f => f.Person.LastName)
                .RuleFor(x => x.CPF, f => f.Person.Cpf())
                .RuleFor(x => x.Email, f => f.Person.Email.ToLower())
                .RuleFor(x => x.DataNascimento, f => f.Person.DateOfBirth)
                .RuleFor(x => x.UF, f => f.Address.StateAbbr())
                .RuleFor(x => x.Cidade, f => f.Person.Address.City)
                .RuleFor(x => x.Bairro, f => f.Person.Address.City)
                .RuleFor(x => x.Logradouro, f => f.Person.Address.Street)
                .RuleFor(x => x.Numero, f => f.Random.Number(1, 1000))
                .RuleFor(x => x.Complemento, f => f.Person.Address.Suite)
                .RuleFor(x => x.Latitude, f => f.Person.Address.Geo.Lat.ToString())
                .RuleFor(x => x.Longitude, f => f.Person.Address.Geo.Lng.ToString())
                .RuleFor(x => x.Celular, f => f.Person.Phone)
                .RuleFor(x => x.CEP, f => f.Person.Address.ZipCode.Replace("-", "").Replace(".", ""))
                .RuleFor(x => x.Instagram, f => f.Internet.Url())
                .RuleFor(x => x.Facebook, f => f.Internet.Url())
                .RuleFor(x => x.ExAluno, f => f.Random.Bool())
                .RuleFor(x => x.EstaEmpregado, f => f.Random.Bool())
                .RuleFor(x => x.JaRealizouEnem, f => f.Random.Bool())
                .RuleFor(x => x.AnoConclusaoEnsinoMedio, f => f.Date.Recent().Year)
                .RuleFor(x => x.NotaExatasEnem, f => f.Random.Float(50, 100))
                .RuleFor(x => x.NotaCienciasDaNaturezaEnem, f => f.Random.Float(50, 100))
                .RuleFor(x => x.NotaHumanasEnem, f => f.Random.Float(50, 100))
                .RuleFor(x => x.NotaLinguagensEnem, f => f.Random.Float(50, 100))
                .RuleFor(x => x.NotaRedacaoEnem, f => f.Random.Float(50, 100))
                .RuleFor(x => x.MediaGeralEnem, f => f.Random.Float(50, 100))
                .RuleFor(x => x.IP, f => f.Internet.Ip())
                .Generate();

            await _service.Adicionar(obj);

            return CustomResponse(obj);
        }
    }
}
