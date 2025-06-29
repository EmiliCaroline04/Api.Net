using ApiFilmes.DTOs;
using FluentValidation;

namespace ApiFilmes.Services.Validations

{
    public class FilmeValidators : AbstractValidator<FilmeDTO>
    {
        public FilmeValidators()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(255).WithMessage("O título deve ter no máximo 255 caracteres.");

            RuleFor(x => x.ClassificacaoEtaria)
                .MaximumLength(10).WithMessage("A classificação etária deve ter no máximo 10 caracteres.");

            RuleFor(x => x.GeneroId)
                .GreaterThan(0).WithMessage("O ID do gênero deve ser maior que zero.");

            RuleFor(x => x.DiretorId)
                .GreaterThan(0).WithMessage("O ID do diretor deve ser maior que zero.");
        }
    }
}

