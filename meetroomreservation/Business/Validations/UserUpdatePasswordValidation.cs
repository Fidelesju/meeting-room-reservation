using FluentValidation;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Validations
{
    public class UserUpdatePasswordValidation : Validation<UserUpdatePasswordRequestModel>
    {

        public UserUpdatePasswordValidation()
        {
            ValidateId();
            ValidateOldPassword();
            ValidateNewPassword();
        }

        private void ValidateId()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(id => CustomValidations.ValidateDatabaseId(id))
                .WithMessage(DefaultErrorMessages.InvalidId);
            ;
        }

        private void ValidateOldPassword()
        {
            RuleFor(s => s.OldPassword)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(passwd => CustomValidations.IsInLengthInterval(8, 100, passwd))
                .WithMessage(DefaultErrorMessages.TextOutOfBounds(8, 100))
            ;
        }

        private void ValidateNewPassword()
        {
            RuleFor(s => s.NewPassword)
                .NotEmpty()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .Must(p => CustomValidations.ValidatePasswordStrength(p))
                .WithMessage(DefaultErrorMessages.PasswordOutFormat())
                ;
        }

        protected override List<PersistenceError> GetPersistenceValidations()
        {

            return new List<PersistenceError>
            {

            };
        }
    }
}