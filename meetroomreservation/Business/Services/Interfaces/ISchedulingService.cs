using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Services.Interfaces
{
    public interface ISchedulingService
    {
        Task<int> CreateScheduling(SchedulingCreateRequest request);
        Task<bool> UpdateScheduling (SchedulingUpdateRequestModel request);
        Task<PaginatedList<SchedulingResponseModel>> GetPaginatedListSchedulingByUserId (int userId, int page, int perPage, Pagination pagination);
        Task<bool> DeleteSchedulingByUserId(int id);
    }
}