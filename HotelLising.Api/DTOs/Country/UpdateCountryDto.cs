using System.ComponentModel.DataAnnotations;

namespace HotelLising.Api.DTOs.Country
{
    public record UpdateCountryDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, MinLength(2)]
        public string ShortName { get; set; } = string.Empty;
    }
}
