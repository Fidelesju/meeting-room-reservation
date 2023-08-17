using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.CoreServices.Interfaces
{
    public interface IEmailManagementService
    {
        bool SendEmail(string receiverEmail, string html, string subject);
    }
}