using Academy.Project.Domain.Customer;
using Academy.Project.Domain.ValueObjects;

namespace Academy.Project.Domain.Commands;

public class CreateCustomerCommand
{
    public string Name { get; set; }
}