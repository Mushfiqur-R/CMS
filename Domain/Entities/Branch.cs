namespace Domain.Entities
{
    public class Branch : BaseEntity
    {
        public int OrganizationId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string District { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public BranchType BranchType { get; set; }

        public int? ManagerId { get; set; }   

        public bool IsActive { get; set; } = true;

        public Organization Organization { get; set; } = null!;

        public User? Manager { get; set; }

        public ICollection<Parcel> OutgoingParcels { get; set; } = new List<Parcel>();

        public ICollection<Parcel> IncomingParcels { get; set; } = new List<Parcel>();

        public ICollection<Courier> Couriers { get; set; } = new List<Courier>();
    }
}
