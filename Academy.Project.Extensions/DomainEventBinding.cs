using Academy.Project.Extensions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(DomainEventBinding.Startup))]
namespace Academy.Project.Extensions
{
    /// <summary>
    /// Starup object
    /// </summary>
    public class DomainEventBinding
    {
        /// <summary>
        /// IWebJobsStartup startup class
        /// </summary>
        public class Startup : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder builder)
            {
                builder.AddDomainEventExtension();
            }
        }
    }
}
