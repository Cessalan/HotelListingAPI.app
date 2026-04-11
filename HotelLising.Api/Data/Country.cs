using System.ComponentModel.DataAnnotations;

namespace HotelLising.Api.Data
{
    public class Country 
    {
        public int CountryId { get; set; }

        [Required]
        public required string Name { get; set; }
        [Required]
        public required string ShortName { get; set; }

        public ICollection<Hotel> Hotels { get; set; } = [];

    }
}
