namespace Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public int? OwnerId { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Branch> Branches { get; set; } = new List<Branch>();

        public User? Owner { get; set; }
    }
}
