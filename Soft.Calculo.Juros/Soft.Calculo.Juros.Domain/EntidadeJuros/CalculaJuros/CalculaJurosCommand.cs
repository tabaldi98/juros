using FluentValidation;
using MediatR;

namespace Soft.Calculo.Juros.Domain.EntidadeJuros.CalculaJuros
{
    public class CalculaJurosCommand : IRequest<string>
    {
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
    }

    public class CalculaJurosCommandValidator : AbstractValidator<CalculaJurosCommand>
    {
        public CalculaJurosCommandValidator()
        {
            RuleFor(p => p.ValorInicial)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.Meses)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
