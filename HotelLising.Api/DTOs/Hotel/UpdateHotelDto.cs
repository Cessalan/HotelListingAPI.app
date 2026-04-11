using HotelLising.Api.DTOs.Hotel;
using System.ComponentModel.DataAnnotations;

public class UpdateHotelDto : CreateHotelDto
{
    [Required]
    public int Id { get; set; }
}