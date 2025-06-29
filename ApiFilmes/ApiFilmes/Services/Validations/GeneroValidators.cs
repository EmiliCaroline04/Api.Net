using ApiFilmes.DTOs;
using FluentValidation;

namespace ApiFilmes.Services.Validations
{
    public class GeneroValidators
    {
        public class GeneroValidator : AbstractValidator<GeneroDTO>
        {
            public GeneroValidator()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("O nome do gênero é obrigatório.")
                    .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");
            }
        }
    }
}
