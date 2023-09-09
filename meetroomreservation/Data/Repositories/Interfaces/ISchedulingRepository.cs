using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Data.Models;

namespace meetroomreservation.Data.Repositories.Interfaces
{
    public interface ISchedulingRepository
    {
        int Create(Scheduling scheduling);
        void Update(Scheduling scheduling);
    }
}