using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class ContactModel
    {
        public int IdCotact { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
