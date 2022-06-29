using System;
using System.Threading.Tasks;
using Hangfire;
using HangfireDemo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailsController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailsController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("welcome/{to}")]
        public IActionResult Welcome(string to)
        {
            var jobId = BackgroundJob.Enqueue(() =>  _mailService.SendWelcomeMailAsync(to));
            return Ok(jobId);
        }

        [HttpPost("delay/{to}")]
        public IActionResult Delay(string to)
        {
            var jobId = BackgroundJob.Schedule(() => _mailService.SendDelayedMailAsync(to), TimeSpan.FromSeconds(10));
            return Ok(jobId);
        }

        [HttpPost("invoice/{to}")]
        public IActionResult Invoice(string to)
        {
            RecurringJob.AddOrUpdate(() => _mailService.SendInvoiceMailAsync(to), Cron.Minutely);
            return Ok();
        }

        [HttpPost("unsubscribe/{to}")]
        public IActionResult Unsubscribe(string to)
        {
            var jobId = BackgroundJob.Enqueue(() => _mailService.UnsubscribeAsync(to));
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine($"jobId: {jobId}, confirm from {to}"));
            return Ok(jobId);
        }
    }
}