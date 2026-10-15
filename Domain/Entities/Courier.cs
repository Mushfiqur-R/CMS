namespace Domain.Entities
{
    public class Courier : BaseEntity
    {
        public int UserId { get; set; }

        public int OrganizationId { get; set; }

        public int? AssignedBranchId { get; set; } 

        public string NationalId { get; set; } = string.Empty;

        public VehicleType VehicleType { get; set; }

        public string? VehicleNumber { get; set; }

        public bool IsAvailable { get; set; } = true;

        public User User { get; set; } = null!;

        public Organization Organization { get; set; } = null!;

        public Branch? AssignedBranch { get; set; }

        public ICollection<Parcel> AssignedParcels { get; set; } = new List<Parcel>();
    }
}
