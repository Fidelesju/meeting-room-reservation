using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.Models;

namespace meetroomreservation.Data.Dao.Interfaces
{
    public interface ISchedulingDb
    {
        Task<PaginatedList<SchedulingResponseModel>> GetPaginatedListSchedulingByUserId (int userId, int page, int perPage, Pagination pagination);
    }
}