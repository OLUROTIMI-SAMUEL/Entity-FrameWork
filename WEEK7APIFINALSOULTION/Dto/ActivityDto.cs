using System.ComponentModel.DataAnnotations;

namespace WEEK7APIFINALSOULTION.Dto
{
    public class ActivityDto
    {
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        public DateTime Starttime { get; set; }
        public string? Duration { get; set; }
        public string? Email { get; set; }
    }
}
