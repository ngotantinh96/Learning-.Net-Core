using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.Models
{
    public class Feedback
    {
        [Required]
        public int FeedbackId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(5000)]
        public string Message { get; set; }

        public bool ContactMe { get; set; }
    }
}
