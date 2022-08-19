using lang.Resources;
using System.ComponentModel.DataAnnotations;

namespace lang.Models
{
    public class User
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationsMessages))]
        public string Nickname { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationsMessages))]
        public string Email { get; set; }

    }
}
