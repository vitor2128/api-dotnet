using System.Data;
using Manager.Domain.Entities;
using FluentValidation;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                    .NotEmpty()
                    .WithMessage("A entidade não pode ser vazia.")

                    .NotNull()
                    .WithMessage("A entidade não pode ser nula;");

            RuleFor(x => x.Name)
                    .NotNull()
                    .WithMessage("O nome não pode ser nulo.")

                    .NotEmpty()
                    .WithMessage("O nome não pode ser vazio")

                    .MinimumLength(3)
                    .WithMessage("O nome deve ter no minimo 3 caracteres")

                    .MaximumLength(80)
                    .WithMessage("O nome deve ter no maximo 80 caracteres");

            RuleFor(x => x.Passoword)
                    .NotNull()
                    .WithMessage("A senha não pode ser nulo.")

                    .NotEmpty()
                    .WithMessage("A senha não pode ser vazio")

                    .MinimumLength(6)
                    .WithMessage("A senha deve ter no minimo 6 caracteres")

                    .MaximumLength(30)
                    .WithMessage("A senha deve ter no maximo 30 caracteres");

            RuleFor(x => x.Email)
                    .NotNull()
                    .WithMessage("O Email não pode ser nulo.")

                    .NotEmpty()
                    .WithMessage("O Email não pode ser vazio")

                    .MinimumLength(10)
                    .WithMessage("O Email deve ter no minimo 10 caracteres")

                    .MaximumLength(180)
                    .WithMessage("O Email deve ter no maximo 180 caracteres")

                    .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                    .WithMessage("O email informado não é valido");
        }
    }
}