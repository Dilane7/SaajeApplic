using System.ComponentModel.DataAnnotations;

namespace SaajeApplic.Models.ViewModel
{
    public class EditRoleVM
    {
        public EditRoleVM()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage ="le Role est requis")]
        public string RoleName { get; set; }
        
        public List<string> Users { get; set; }
    }
}
