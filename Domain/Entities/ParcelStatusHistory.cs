namespace Domain.Entities
{
    public class ParcelStatusHistory : BaseEntity
    {
        public int ParcelId { get; set; }

        public ParcelStatus Status { get; set; }

        public string? Location { get; set; }

        public string? Remarks { get; set; }

        public int ChangedByUserId { get; set; }

        public Parcel Parcel { get; set; } = null!;

        public User ChangedByUser { get; set; } = null!;
    }
}
