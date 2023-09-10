namespace meetroomreservation.CoreServices.Interfaces
{
    public interface ICryptographyService
    {
        public string GetMd5Crypto(string text);
    }
}