namespace meetroomreservation.CoreServices.Interfaces
{
    public interface IEmailManagementService
    {
        bool SendEmail(string receiverEmail, string html, string subject);
    }
}