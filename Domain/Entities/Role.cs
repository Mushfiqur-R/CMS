namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public RoleType RoleType { get; set; }

        public bool IsGlobal { get; set; } = false;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
