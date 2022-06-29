using Microsoft.Extensions.Logging;

namespace HangfireDemo.API.Services
{
    public class MailService: IMailService
    {
        private readonly ILogger<MailService> _logger;

        public MailService(ILogger<MailService> logger)
        {
            _logger = logger;
        }

        public void SendWelcomeMailAsync(string to)
        {
            _logger.LogInformation("WELCOME to {Unknown}", to);
        }

        public void SendDelayedMailAsync(string to)
        {
            _logger.LogInformation("DEPLAY to {Unknown}", to);
        }

        public void SendInvoiceMailAsync(string to)
        {
            _logger.LogInformation("INVOICE to {Unknown}", to);
        }

        public void UnsubscribeAsync(string to)
        {
            _logger.LogInformation("UNSUBSCRIBE {Unknown}", to);
        }
    }
}