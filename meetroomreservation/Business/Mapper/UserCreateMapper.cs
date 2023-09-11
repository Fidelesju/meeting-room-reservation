using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Business.Utils;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Mapper
{
    public class UserCreateMapper : Mapper<UserCreateRequestModel>, IUserCreateMapper
    {
        private readonly User _user;

        public UserCreateMapper()
        {
            _user = new User();
        }

        public User GetUser()
        {
            HashMd5 hashMd5 = new HashMd5();

            _user.Email = BaseMapping.Email;
            _user.Password = hashMd5.EncryptMD5(BaseMapping.Password);
            _user.Name = BaseMapping.Name;
            _user.IsActive = 1;
            return _user;
        
        }
    }
}