using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Services.Interfaces
{
    public interface ISchedulingService
    {
        Task<int> CreateScheduling(SchedulingCreateRequest request);
    }
}