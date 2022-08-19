using System.ComponentModel.DataAnnotations;

namespace lang.Models
{
    public class User
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
