using meetroomreservation.Data.Models;

namespace meetroomreservation.Data.Repositories.Interfaces
{
    public interface ISchedulingRepository
    {
        int Create(Scheduling scheduling);
        void Update(Scheduling scheduling);
        Task<bool> Delete (int id);
    }
}