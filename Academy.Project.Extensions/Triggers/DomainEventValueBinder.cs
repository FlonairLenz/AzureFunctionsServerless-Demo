using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Academy.Project.Extensions.Triggers
{
    public class DomainEventValueBinder: IValueBinder
    {
        private object _value;

        public DomainEventValueBinder(object value)
        {
            this._value = value;
        }

        public Type Type => typeof(INotification);

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(this._value);
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            this._value = value;
            return Task.CompletedTask;
        }

        public string ToInvokeString()
        {
            return this._value?.ToString();
        }
    }
}
