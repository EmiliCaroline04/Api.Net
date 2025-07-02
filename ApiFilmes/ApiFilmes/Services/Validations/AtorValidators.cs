using ApiFilmes.DTOs;
using FluentValidation;
using System;

namespace ApiFilmes.Services.Validations
{
    public class AtorValidators
    {
        // (Orientada Objeto) Classe de validação específica para AtorDTO
        public class AtorValidator : AbstractValidator<AtorDTO>
        {

            // (Orientação Funcionar) nome não pode ser vazio
            public AtorValidator()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("O nome do ator é obrigatório.")
                    .MaximumLength(255).WithMessage("O nome deve ter no máximo 255 caracteres.");

                RuleFor(x => x.DataNascimento)
                    .LessThan(DateTime.Now).When(x => x.DataNascimento.HasValue)
                    .WithMessage("A data de nascimento deve ser menor que a data atual.");
            }
        }
    }
}