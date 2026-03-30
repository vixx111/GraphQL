using System.ComponentModel.DataAnnotations;

namespace GraphQL.Client.DataAccess.Model
{
    public class CreateAuthorModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone format")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int Age { get; set; }
    }
}
