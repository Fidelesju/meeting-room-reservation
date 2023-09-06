using meetroomreservation.Data.RequestModel;
using meetroomreservation.Data.ResponseModel;

namespace meetroomreservation.Business.Services.Interfaces
{
    public interface IAccessService
    {
        Task<UserLoginResponseModel> AuthenticateUser(UserLoginRequestModel request);
    }
}