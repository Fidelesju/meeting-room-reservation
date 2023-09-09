using FluentValidation;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Validations
{
      public class SchedulingCreateValidation : Validation<SchedulingCreateRequest>
    {
        public SchedulingCreateValidation()
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(s => s.Data)
                .NotNull()
                .WithMessage(DefaultErrorMessages.RequiredField)
                .WithMessage(DefaultErrorMessages.TextOutOfBounds(10, 50))
                ;
        }

        protected override List<PersistenceError> GetPersistenceValidations()
        {
            throw new NotImplementedException();
        }
    }
}