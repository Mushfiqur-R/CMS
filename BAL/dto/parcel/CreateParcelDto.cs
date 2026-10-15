namespace BAL.dto.parcel
{
    public class CreateParcelDto
    {
        public string SenderName { get; set; } = string.Empty;
        public string SenderPhone { get; set; } = string.Empty;
        public string SenderAddress { get; set; } = string.Empty;

        public string ReceiverName { get; set; } = string.Empty;
        public string ReceiverPhone { get; set; } = string.Empty;
        public string ReceiverAddress { get; set; } = string.Empty;
        public string ReceiverCity { get; set; } = string.Empty;

        public decimal Weight { get; set; }
        public string Description { get; set; } = string.Empty;

        public int OriginBranchId { get; set; }
        public int DestinationBranchId { get; set; }
    }
}
