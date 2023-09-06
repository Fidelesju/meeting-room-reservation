using FluentValidation;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Validations
{
    public class UserUpdateValidation : Validation<UserUpadateRequestModel>
    {
        public UserUpdateValidation()
        {
            ValidateName();
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

        protected override List<PersistenceError> GetPersistenceValidations()
        {
            throw new NotImplementedException();
        }
    }
}