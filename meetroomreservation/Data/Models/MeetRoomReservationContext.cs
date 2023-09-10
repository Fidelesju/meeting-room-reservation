using Microsoft.EntityFrameworkCore;

namespace meetroomreservation.Data.Models
{
    public class MeetRoomReservationContext : DbContext
    {
        public MeetRoomReservationContext (DbContextOptions<MeetRoomReservationContext> options) :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Scheduling> Scheduling { get; set; }
    }
}