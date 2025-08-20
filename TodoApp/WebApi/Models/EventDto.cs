using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class EventDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool Allday { get; set; }
    }
}
