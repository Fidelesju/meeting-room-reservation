using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.Data.Models
{
    public class Scheduling
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Data { get; set; }
    }
}