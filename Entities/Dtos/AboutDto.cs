using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record AboutDto
    {

        public int AboutId { get; init; }

        [Required]
        public string? OurStory { get; set; }

        [Required]
        public string? OurMission { get; set; }


        public bool IsActive { get; init; }
    }
}