using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.CoreServices.Interfaces
{
    public interface ICryptographyService
    {
        public string GetMd5Crypto(string text);
    }
}