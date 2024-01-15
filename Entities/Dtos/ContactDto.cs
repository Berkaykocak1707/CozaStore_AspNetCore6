using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ContactDto
    {

        public int ContactId { get; init; }

        [Required]
        [StringLength(100)]
        public string? EmailAddress { get; init; }

        [Required]
        [StringLength(100)]
        public string? Message { get; init; }
    }
}