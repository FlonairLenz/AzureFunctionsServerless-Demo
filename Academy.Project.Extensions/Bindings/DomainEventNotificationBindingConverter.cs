using Microsoft.Azure.WebJobs;

namespace Academy.Project.Extensions.Bindings
{
    internal class DomainEventNotificationBindingConverter<T> : IConverter<DomainEventNotificationAttribute, IAsyncCollector<T>>
    {
        /// <summary>
        /// Extension Config Provider
        /// </summary>
        private DomainEventExtensionConfigProvider _provider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provider">Extension Config Provider instance</param>
        public DomainEventNotificationBindingConverter(DomainEventExtensionConfigProvider provider)
        {
            this._provider = provider;
        }

        /// <summary>
        /// Convert, create the async collector class
        /// </summary>
        /// <param name="input">DomainEvent attribute instance</param>
        /// <returns>Returns the async collector instance</returns>
        public IAsyncCollector<T> Convert(DomainEventNotificationAttribute input)
        {
            return new DomainEventNotificationAsyncCollector<T>(this._provider.CreateContext(input));
        }
    }
}
