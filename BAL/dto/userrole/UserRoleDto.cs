namespace BAL.dto.userrole
{

    public class AssignRoleDto
    {

        public int TargetUserId { get; set; }
        public int RoleId { get; set; }
        public int? BranchId { get; set; }
    }

    public class RevokeRoleDto
    {
        public int TargetUserId { get; set; }
        public int RoleId { get; set; }
        public int? BranchId { get; set; }
    }

    public class UserRoleResponseDto
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; } = string.Empty;

        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public bool IsGlobalRole { get; set; }

        public int? BranchId { get; set; }
        public string? BranchName { get; set; }

        public string? AssignedByName { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}
