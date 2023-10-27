namespace Academy.Project.Domain.Enums;

public enum OrderStatus
{
    Planned = 0,
    InPackaging = 1,
    ReadyToShip = 2,
    InShipping = 3,
    Completed = 4,
    Canceled = 5
}