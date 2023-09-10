namespace meetroomreservation.CoreServices.Interfaces
{
    public interface IFileManagementService
    {

        bool StoreStreamContent(Stream stream, string fileName);
        public string LogFilePath();
        public string GetBaseUrl();
    }
}