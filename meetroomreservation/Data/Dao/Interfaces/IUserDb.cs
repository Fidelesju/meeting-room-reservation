namespace meetroomreservation.Data.Dao.Interfaces
{
    public interface IUserDb
    {
        Task<bool> UserPasswordIsValid(int userId, string oldPassword);
    }
}