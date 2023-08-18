using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.Data.Expections
{
    public class DatabaseQueryFailureException : Exception
    {
        public DatabaseQueryFailureException(string message, Exception exception) : base(message, exception)
        {
            Console.WriteLine("Failure on query to database.");
        }
    }
}