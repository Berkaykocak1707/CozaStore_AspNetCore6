using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record InformationDto
    {

        public int? InfoId { get; init; }

        [Required]
        [StringLength(100)]
        public string? Address { get; init; }

        [Required]
        [StringLength(100)]
        public string? Phone { get; init; }

        [Required]
        [StringLength(100)]
        public string? Email { get; init; }


        public bool IsActive { get; init; }
    }
}