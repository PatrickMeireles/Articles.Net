using Articles.Application.Interfaces;
using Articles.Application.ViewModel;
using FluentValidation;

namespace Articles.Application.Validation
{
    public class UserValidation
    {
    }

    public class CreateUserValidation : AbstractValidator<CreateUserViewModel>
    {
        private readonly IUserApplication _user;
        public CreateUserValidation(IUserApplication user)
        {
            _user = user;

            RuleFor(x => x.Email)
                    .MaximumLength(180).WithMessage("Email cannot have more than 180 characters.")
                    .NotEmpty().WithMessage("Email cannot be empty.")
                    .NotNull().WithMessage("Email cannot be empty.");

            RuleFor(x => x.Password)
                   .NotEmpty().WithMessage("Password cannot be empty.")
                    .NotNull().WithMessage("Password cannot be empty.");

            RuleFor(x => x)
                   .Must(x => ExistWithSameEmail(x.Email)).WithMessage("Already user with same email");
        }

        private bool ExistWithSameEmail(string email) => _user.GetByEmail(email).GetAwaiter().GetResult() == null;
    }
}
