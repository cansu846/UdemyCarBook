using FluentValidation;
using UdemyCarBook.Dtos.AppUserDtos;

namespace UdemyCarBook.WebUI.FluentValidation.RegisterValidations
{
    public class RegisterValidator:AbstractValidator<CreateUserDto>
    {
        public RegisterValidator() {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username can not be empty")
                .MinimumLength(2).WithMessage("Name must be least 2 character");

            RuleFor(x => x.Password)
              .NotEmpty().WithMessage("Password can not be empty")
              .MinimumLength(3).WithMessage("Password must be least 3 character");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Not compatible with password");
        }  
    }
}
