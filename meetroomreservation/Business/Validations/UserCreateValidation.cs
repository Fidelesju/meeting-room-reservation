using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.RequestModel;
using FluentValidation;

namespace meetroomreservation.Business.Validations
{
    public class UserCreateValidation : Validation<UserCreateRequestModel>
    {
        public UserCreateValidation()
        {
            ValidateEmail();
            ValidateName();
            ValidatePassword();
        }

        private void ValidateEmail()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(email => CustomValidations.IsInLengthInterval(10, 50, email))
                .WithMessage(DefaultErrorMessages.TextOutOfBounds(10, 50))
                ;
        }


        private void ValidateName()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(name => CustomValidations.IsInLengthInterval(10, 50, name))
                .WithMessage(DefaultErrorMessages.TextOutOfBounds(10, 50))
                ;
        }

        private void ValidatePassword()
        {
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(password => CustomValidations.ValidatePasswordStrength(password))
                .WithMessage(DefaultErrorMessages.PasswordOutFormat())
                ;
        }
        protected override List<PersistenceError> GetPersistenceValidations()
        {
            throw new NotImplementedException();
        }
    }
}