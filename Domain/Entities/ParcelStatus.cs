namespace Domain.Entities
{
    public enum ParcelStatus
    {
        Pending = 1,
        PickedUp = 2,
        AtOriginBranch = 3,
        InTransit = 4,
        AtDestinationBranch = 5,
        OutForDelivery = 6,
        Delivered = 7,
        FailedDelivery = 8,
        Returned = 9,
        Cancelled = 10
    }
}
