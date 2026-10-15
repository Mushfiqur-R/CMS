namespace Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public int? BranchId { get; set; }

        public int? AssignedByUserId { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;

        public Role Role { get; set; } = null!;

        public Branch? Branch { get; set; }

        public User? AssignedBy { get; set; }
    }
}
