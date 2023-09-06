using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.Data.Dao
{
     public class AcessDb
    {
        public readonly IConfiguration Configuration;
        public readonly IWebHostEnvironment HostingEnviroment;
        public readonly string StringConnection = string.Empty;

        public AcessDb(IConfiguration configuration,
            IWebHostEnvironment hostingEnviroment)
        {
            Configuration = configuration;
            HostingEnviroment = hostingEnviroment;
            StringConnection = "server=localhost;port=3306;database=meetroomreservationdb;user=fidelesju;password=gCR7!5dDpXtc&9o; Persist Security Info= False; Connect Timeout=300";
        }

        // public string ConnectionArray()
        // {
        //     string connectionName = @"Production";

        //     if (HostingEnviroment.EnvironmentName.Equals(@"Development"))
        //     {
        //         connectionName = "Development";
        //     }

        //     return connectionName;
        // }
    }
}