using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BrihanBocanegra.Models
{
    public class ContactFormModel
    {
        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(18)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }
    }

}
