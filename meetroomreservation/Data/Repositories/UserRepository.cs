using meetroomreservation.Data.Models;
using meetroomreservation.Data.Repositories.Interfaces;

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
    }
}
