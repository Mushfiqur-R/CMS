namespace Domain.Entities
{
    public class Parcel : BaseEntity
    {
        public string TrackingNumber { get; set; } = string.Empty;

        public int SenderUserId { get; set; }

        public string ReceiverName { get; set; } = string.Empty;

        public string ReceiverPhone { get; set; } = string.Empty;

        public string ReceiverAddress { get; set; } = string.Empty;

        public string ReceiverCity { get; set; } = string.Empty;

        public string ReceiverDistrict { get; set; } = string.Empty;

        public int OrganizationId { get; set; }

        public int? OriginBranchId { get; set; }

        public int? DestinationBranchId { get; set; }

        public int? AssignedCourierId { get; set; }

        public decimal Weight { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public string? Description { get; set; }

        public decimal DeclaredValue { get; set; }

        public ServiceType ServiceType { get; set; } = ServiceType.Standard;

        public ParcelStatus Status { get; set; } = ParcelStatus.Pending;

        public DateTime? PickupDate { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? ActualDeliveryDate { get; set; }

        public User SenderUser { get; set; } = null!;

        public Organization Organization { get; set; } = null!;

        public Branch? OriginBranch { get; set; }

        public Branch? DestinationBranch { get; set; }

        public Courier? AssignedCourier { get; set; }

        public ICollection<ParcelStatusHistory> StatusHistories { get; set; } = new List<ParcelStatusHistory>();

        public Payment? Payment { get; set; }
    }
}
