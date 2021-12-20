using Bogus;
using Bogus.Extensions.Brazil;
using Einstein.Core.Helpers;
using Einstein.Core.Models;
using Einstein.Core.Repositories;
using Einstein.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Einstein.Api.Controllers
{
    public class ProfessorController : MainController
    {
        private readonly IProfessorRepository _repository;
        private readonly ProfessorService _service;

        public ProfessorController(
            IProfessorRepository repository,
            INotificador notificador,
            IUser appUser,
            ProfessorService service) : base(notificador, appUser)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Professor>> Listar()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<Professor?> Obter(Guid id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Professor obj)
        {
            obj = new Faker<Professor>("pt_BR")
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
                .RuleFor(x => x.IP, f => f.Internet.Ip())
                .RuleFor(x => x.TrabalhaEmOutroLocal, f => f.Random.Bool())
                .RuleFor(x => x.Graduacao, f => f.Random.Word())
                .RuleFor(x => x.LocalOndeTrabalha, f => f.Random.Word())
                .RuleFor(x => x.CargaHorariaSemanal, f => f.Random.Float(1, 20))
                .RuleFor(x => x.Horario, f => new[]
                {
                    new ProfessorHorario
                    {
                        DiaDaSemana = DayOfWeek.Monday,
                        Horarios = new[]
                        {
                            new ProfessorHorarioItem
                            {
                                HoraInicio = DateTime.Now.ToString("HH:mm"),
                                HoraFim = DateTime.Now.ToString("HH:mm"),
                            }
                        },
                    },
                    new ProfessorHorario
                    {
                        DiaDaSemana = DayOfWeek.Friday,
                        Horarios = new[]
                        {
                            new ProfessorHorarioItem
                            {
                                HoraInicio = DateTime.Now.ToString("HH:mm"),
                                HoraFim = DateTime.Now.ToString("HH:mm"),
                            }
                        },
                    }
                })
                .Generate();

            await _service.Adicionar(obj);

            return CustomResponse(obj);
        }
    }
}
