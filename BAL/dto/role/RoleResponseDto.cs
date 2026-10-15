using Domain.Entities;

namespace BAL.dto.role
{

    public class RoleResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RoleType RoleType { get; set; }
        public string RoleTypeName => RoleType.ToString();
        public bool IsGlobal { get; set; }
    }
}
