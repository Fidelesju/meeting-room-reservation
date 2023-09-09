using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.Data.RequestModel
{
    public class SchedulingCreateRequest
    {
        public int UserId { get; set; }
        public string? Data { get; set; } // Altere o tipo para string

        // Método para converter a string em DateTime
        public DateTime GetDataAsDateTime()
        {
            if (DateTime.TryParseExact(Data, "dd-MM-yy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            throw new ArgumentException("Formato de data e hora inválido.");
        }
    }
}
