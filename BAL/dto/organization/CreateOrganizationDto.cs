using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BAL.dto.organization
{
    public class CreateOrganizationDto
    {
        // ── Organization Information ────────────────────────────────────────────
        [Required(ErrorMessage = "Organization name is required.")]
        [StringLength(300, ErrorMessage = "Name cannot exceed 300 characters.")]
        [DefaultValue("SpeedX Courier Ltd.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Organization email is required.")]
        [EmailAddress(ErrorMessage = "Invalid organization email format.")]
        [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
        [DefaultValue("contact@speedx.com")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Organization phone number is required.")]
        [Phone(ErrorMessage = "Invalid organization phone number format.")]
        [StringLength(15, ErrorMessage = "Phone cannot exceed 15 characters.")]
        [DefaultValue("01711223344")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Organization address is required.")]
        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
        [DefaultValue("House 10, Road 4, Banani")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Organization city is required.")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        [DefaultValue("Dhaka")]
        public string City { get; set; } = string.Empty;

        // ── Owner (User) Account Information ────────────────────────────────────
        [Required(ErrorMessage = "Owner full name is required.")]
        [StringLength(200, ErrorMessage = "Owner name cannot exceed 200 characters.")]
        [DefaultValue("Mushfiqur Rahman")]
        public string OwnerFullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Owner email is required.")]
        [EmailAddress(ErrorMessage = "Invalid owner email format.")]
        [StringLength(150, ErrorMessage = "Owner email cannot exceed 150 characters.")]
        [DefaultValue("mushfiq@speedx.com")]
        public string OwnerEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Owner phone is required.")]
        [Phone(ErrorMessage = "Invalid owner phone format.")]
        [StringLength(15, ErrorMessage = "Owner phone cannot exceed 15 characters.")]
        [DefaultValue("01811223344")]
        public string OwnerPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Owner password is required.")]
        [MinLength(6, ErrorMessage = "Owner password must be at least 6 characters long.")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        [DefaultValue("StrongPassword123@")]
        public string OwnerPassword { get; set; } = string.Empty;
    }
}
