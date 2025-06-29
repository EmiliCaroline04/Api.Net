using ApiFilmes.DTOs;
using FluentValidation;
using System;

namespace ApiFilmes.Services.Validations
{
    public class AvaliacaoValidators
    {
        public class AvaliacaoValidator : AbstractValidator<AvaliacaoDTO>
        {
            public AvaliacaoValidator()
            {
                RuleFor(x => x.FilmeId)
                    .GreaterThan(0).WithMessage("O ID do filme deve ser maior que zero.");

                RuleFor(x => x.Nota)
                    .InclusiveBetween(0, 10).WithMessage("A nota deve ser entre 0 e 10.");

                RuleFor(x => x.Comentario)
                    .MaximumLength(1000).WithMessage("O comentário deve ter no máximo 1000 caracteres.");

                RuleFor(x => x.DataAvaliacao)
                    .LessThanOrEqualTo(DateTime.Now).When(x => x.DataAvaliacao.HasValue)
                    .WithMessage("A data de avaliação não pode ser futura.");
            }
        }
    }
}