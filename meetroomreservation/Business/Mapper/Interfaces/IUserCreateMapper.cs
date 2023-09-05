using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Mapper.Interfaces
{
    public interface IUserCreateMapper
    {
        User GetUser();
        void SetBaseMapping(UserCreateRequestModel request);
    }
}