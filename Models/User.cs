using lang.Resources;
using System.ComponentModel.DataAnnotations;

namespace lang.Models
{
    public class User
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationsMessages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "NickNameWrongLength", ErrorMessageResourceType = typeof(ValidationsMessages))]
        public string Nickname { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationsMessages))]
        [EmailAddress(ErrorMessageResourceName = "WrongEmail", ErrorMessageResourceType = typeof(ValidationsMessages))]
        public string Email { get; set; }

    }
}
