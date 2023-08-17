using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.CoreServices.Interfaces
{
   
    public interface IFileManagementService
    {

        bool StoreStreamContent(Stream stream, string fileName);

        public string LogFilePath();
        public string GetBaseUrl();
    }
}