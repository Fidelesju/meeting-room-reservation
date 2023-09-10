using meetroomreservation.CoreServices.Interfaces;

namespace meetroomreservation.CoreServices
{
    public class FileManagementService : IFileManagementService
    {
        private const string UploadsFolder = "wwwroot/uploads";
        private readonly IConfiguration _configuration;
        public string UploadsAbsoluteFolder;

        public FileManagementService(IConfiguration configuration)
        {
            _configuration = configuration;
            UploadsAbsoluteFolder = configuration.GetValue<string>("HostSettings:BaseUrl");
        }

        public string GetBaseUrl()
        {
            return _configuration.GetValue<string>("HostSettings:BaseUrl");
        }


        public string LogFilePath()
        {
            string directory;
            string basePath;
            string logsFolder;

            directory = Directory.GetCurrentDirectory();
            basePath = Path.Combine(directory, "wwwroot", "logs");
            logsFolder = Path.Combine(basePath, $"log-{DateTime.Now:yyyy-M-d_dddd}.log");
            return logsFolder;
        }



        public bool StoreStreamContent(Stream stream, string fileName)
        {
            FileStream output;
            try
            {
                output = File.Open(fileName, FileMode.Create);
                stream.CopyTo(output);
                output.Close();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}