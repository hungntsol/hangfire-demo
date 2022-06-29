namespace HangfireDemo.API.Services
{
    public interface IMailService
    {
        void SendWelcomeMailAsync(string to);
        void SendDelayedMailAsync(string to);
        void SendInvoiceMailAsync(string to);
        void UnsubscribeAsync(string to);
    }
}