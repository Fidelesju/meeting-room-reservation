using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.Data.Dao.Interfaces
{
    public interface IUserDb
    {
        Task<bool> UserPasswordIsValid(int userId, string oldPassword);
    }
}