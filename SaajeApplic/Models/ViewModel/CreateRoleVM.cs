using System.ComponentModel.DataAnnotations;

namespace SaajeApplic.Models.ViewModel
{
    public class CreateRoleVM
    {
        [Required(ErrorMessage = "Le nom du role est obligatoire ")]
        public string RoleName { get; set; }
    }
}
