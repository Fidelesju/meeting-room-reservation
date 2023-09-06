using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.Data.ResponseModel
{
    public class UserResponseModel
    {
         public int UserId { get; set; }
         public string? Email { get; set; }
         public string? Name { get; set; }
         public string? Password { get; set; }
    }
}