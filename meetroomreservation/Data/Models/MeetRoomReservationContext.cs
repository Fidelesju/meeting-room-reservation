using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace meetroomreservation.Data.Models
{
    public class MeetRoomReservationContext : DbContext
    {
        public MeetRoomReservationContext (DbContextOptions<MeetRoomReservationContext> options) :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}