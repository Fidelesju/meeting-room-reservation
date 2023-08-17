using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.CoreServices.Interfaces
{
    public interface ILoggerService
    {
        Task LogError(Exception exception, HttpContext context);
        Task LogErrorServicesBackground(Exception exception);
        Task LogInfo(string info);
    }
}