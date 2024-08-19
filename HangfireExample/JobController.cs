using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangfireExample.Controllers;


[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private readonly IBackgroundJobClient _backgroundJobClient;

    public JobController(IBackgroundJobClient backgroundJobClient)
    {
        _backgroundJobClient = backgroundJobClient;
    }

    [HttpPost("enqueue")]
    public IActionResult EnqueueJob()
    {
        _backgroundJobClient.Enqueue(() => Console.WriteLine("Background job executed in .NET Core 8!"));
        return Ok("Job has been enqueued.");
    }

    [HttpPost("schedule")]
    public IActionResult ScheduleJob()
    {
        _backgroundJobClient.Schedule(() => Console.WriteLine("Scheduled job executed in .NET Core 8!"), TimeSpan.FromMinutes(1));
        return Ok("Job has been scheduled.");
    }
}
