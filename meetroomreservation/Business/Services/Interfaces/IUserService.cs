using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUser (UserCreateRequestModel request);
        
    }
}