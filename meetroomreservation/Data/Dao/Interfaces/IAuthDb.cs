using meetroomreservation.Data.ResponseModel;

namespace meetroomreservation.Data.Dao.Interfaces
{
    public interface IAuthDb
    {
        Task<UserLoginResponseModel> AuthenticateUser(string email, string password);
    }
}