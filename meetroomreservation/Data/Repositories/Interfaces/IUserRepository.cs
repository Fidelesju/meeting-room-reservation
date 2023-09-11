using meetroomreservation.Data.Models;

namespace meetroomreservation.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
         public int Create(User user);
         public void Update(User user);
         Task<bool> UpdateUserPassword(int userId, string password);
         Task<bool> Delete (int id);
    }
}