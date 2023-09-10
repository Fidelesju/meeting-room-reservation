using System.Globalization;

namespace meetroomreservation.Data.RequestModel
{
    public class SchedulingUpdateRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Data { get; set; } // Altere o tipo para string

        // Método para converter a string em DateTime
        public DateTime GetDataAsDateTime()
        {
            if (DateTime.TryParseExact(Data, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            throw new ArgumentException("Formato de data e hora inválido.");
        }
    }
}