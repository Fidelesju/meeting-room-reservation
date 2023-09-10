using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Services.Interfaces
{
    public interface ISchedulingService
    {
        Task<int> CreateScheduling(SchedulingCreateRequest request);
        Task<bool> UpdateScheduling (SchedulingUpdateRequestModel request);
    }
}