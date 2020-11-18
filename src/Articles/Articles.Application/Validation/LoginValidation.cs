using Articles.Application.Interfaces;
using Articles.Application.ViewModel;
using FluentValidation;

namespace Articles.Application.Validation
{
    public class LoginValidation : AbstractValidator<LoginViewModel>
    {
        private readonly IUserApplication _user;

        public LoginValidation(IUserApplication user)
        {
            _user = user;

            RuleFor(x => x.Login)
                   .NotEmpty().WithMessage("Login não foi informado.")
                   .NotNull().WithMessage("Login não foi informado.");

            RuleFor(x => x.Password)
                   .NotEmpty().WithMessage("Senha não foi informado.")
                   .NotNull().WithMessage("Senha não foi informado.");

            RuleFor(x => x)
                    .Must(x => Validate(x))
                    .WithMessage("Usuário não encontrado.");

        }

        private new bool Validate(LoginViewModel model)
        {
            return _user.Authenticate(model.Login, model.Password)
                        .GetAwaiter()
                        .GetResult() != null;
        }
    }
}
