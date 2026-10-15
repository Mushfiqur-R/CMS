namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int ParcelId { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        public string? TransactionId { get; set; }

        public DateTime? PaidAt { get; set; }

        public string? Notes { get; set; }

        public Parcel Parcel { get; set; } = null!;
    }
}
