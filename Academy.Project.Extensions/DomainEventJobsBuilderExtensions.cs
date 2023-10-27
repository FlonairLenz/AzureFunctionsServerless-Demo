using System.Threading.Channels;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Project.Extensions
{
    public static class DomainEventWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddDomainEventExtension(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }


            builder.AddExtension<DomainEventExtensionConfigProvider>();
            builder.Services.AddSingleton(Channel.CreateUnbounded<string>());
            builder.Services.AddSingleton(Channel.CreateUnbounded<INotification>());
            builder.Services.AddSingleton<IDomainEventChannelFactory, DomainEventChannelFactory>();

            return builder;
        }
    }
}
