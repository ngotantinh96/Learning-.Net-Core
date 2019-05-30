using System.ComponentModel.DataAnnotations;

namespace WebAppTagHelper.Models
{
    public class ModelAddress
    {
        public int Id { get; internal set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; internal set; }
    }
}
