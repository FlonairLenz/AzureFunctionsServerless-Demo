using Academy.Project.Restful;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(Startup))]
namespace Academy.Project.Restful;

public class Startup : IWebJobsStartup
{
    public void Configure(IWebJobsBuilder builder)
    {
    }
}