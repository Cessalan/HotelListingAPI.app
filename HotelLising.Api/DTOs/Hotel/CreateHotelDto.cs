using System.ComponentModel.DataAnnotations;

namespace HotelLising.Api.DTOs.Hotel
{
    public class CreateHotelDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Address { get; set; }

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }    
}
