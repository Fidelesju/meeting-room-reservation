using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Mapper.Interfaces
{
    public interface ISchedulingUpdateMapper
    {
        Scheduling GetScheduling();
        void SetBaseMapping(SchedulingUpdateRequestModel request);
    }
}