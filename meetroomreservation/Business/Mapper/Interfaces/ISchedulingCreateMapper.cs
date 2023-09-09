using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Mapper.Interfaces
{
    public interface ISchedulingCreateMapper
    {
        Scheduling GetScheduling();
        void SetBaseMapping(SchedulingCreateRequest request);
    }
}