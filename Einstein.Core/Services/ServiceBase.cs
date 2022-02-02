﻿using Einstein.Core.Helpers;
using FluentValidation;
using FluentValidation.Results;

namespace Einstein.Core.Services
{
    public abstract class ServiceBase
    {
        private readonly INotificador _notificador;    

        protected ServiceBase(INotificador notificador)
        {
            _notificador = notificador;   
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Notificar(error.ErrorMessage);
        }

        protected void Notificar(string mensagem) => _notificador.Handle(new Notificacao(mensagem));

        protected async Task<bool> ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var result = await validacao.ValidateAsync(entidade);

            if (!result.IsValid)
            {
                Notificar(result);
                return false;
            }

            return true;
        }
    }
}
