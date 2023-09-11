using meetroomreservation.Data.Models;
using meetroomreservation.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace meetroomreservation.Data.Repositories
{
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(MeetRoomReservationContext context) : base(context)
        {

        }

        public int Create(Scheduling scheduling)
        {
            DbSet.Add(scheduling);
            Context.SaveChanges();
            return scheduling.Id;
        }

        public void Update(Scheduling scheduling)
        {
            DbSet.Update(scheduling);
            Context.SaveChanges();
        }

        public async Task<bool> Delete (int id)
        {
            string sql;
            int rowsAffected;
            sql = @"
                    DELETE FROM scheduling
                WHERE id = {0};
                ";
            rowsAffected = await Context.Database.ExecuteSqlRawAsync(sql, id);
            return rowsAffected > 0;
        }
    }
}
