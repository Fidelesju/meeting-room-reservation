using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Mapper
{
    public class UserUpdateMapper : Mapper<UserUpadateRequestModel>, IUserUpdateMapper
    {
        private readonly User _user;

        public UserUpdateMapper()
        {
            _user = new User();
        }

        public User GetUser()
        {
            _user.Id = BaseMapping.Id;
            _user.Email = BaseMapping.Email;
            _user.Name = BaseMapping.Name;
            return _user;
        }
    }
}