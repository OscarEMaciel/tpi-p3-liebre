using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class ClientCreateRequest
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
