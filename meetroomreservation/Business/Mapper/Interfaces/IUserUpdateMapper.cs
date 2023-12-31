using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Mapper.Interfaces
{
    public interface IUserUpdateMapper : IMapper<UserUpadateRequestModel>
    {
        public User GetUser();
    }
}