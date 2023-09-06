using meetroomreservation.Data.Models;
using meetroomreservation.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace meetroomreservation.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MeetRoomReservationContext context) : base(context)
        {

        }

        public int Create(User user)
        {
            DbSet.Add(user);
            Context.SaveChanges();
            return user.Id;
        }

        public void Update(User user)
        {
            DbSet.Update(user);
            Context.SaveChanges();
        }

        public async Task<bool> UpdateUserPassword(int userId, string password)
        {
            string sql;
            int rowsAffected;

            // TODO: CRITICAL FAILURE POINT. This query is vulnerable to SQL Injection.
            sql = @"
                SET @userId = {1};
                SET @password = {0};
                UPDATE
                    users u
                SET
                    u.password = @password
                WHERE
                    u.id = @userId;
            ";
            rowsAffected = await Context.Database.ExecuteSqlRawAsync(sql, password, userId);
            return rowsAffected > 0;
        }
    }
}
