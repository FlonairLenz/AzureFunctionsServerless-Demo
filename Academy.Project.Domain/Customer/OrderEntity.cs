using Academy.Project.Domain.Enums;

namespace Academy.Project.Domain.Customer;

public class OrderEntity
{
    string Id { get; set; }
    string Number { get; set; }
    OrderStatus Status { get; set; }
}