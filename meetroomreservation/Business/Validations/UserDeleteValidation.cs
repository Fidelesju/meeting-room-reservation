using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Data.ApplicationModels;

namespace meetroomreservation.Business.Validations
{
    public class UserDeleteValidation : Validation<int>
    {
        protected override List<PersistenceError> GetPersistenceValidations()
        {
            throw new NotImplementedException();
        }
    }
}