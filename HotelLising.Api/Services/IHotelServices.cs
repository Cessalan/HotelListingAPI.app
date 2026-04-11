using HotelLising.Api.DTOs.Hotel;
using HotelLising.Api.Results;

namespace HotelLising.Api.Services
{
    public interface IHotelServices
    {
        Task<ICustomResult> CreateHotel(CreateHotelDto hotelDto);
        Task<ICustomResult> DeleteHotelAsync(DeleteHotelDTO deleteHotelDTO);
        Task<Result<GetHotelDto?>> GetHotelAsync(int hotelId);
        Task<Result<IEnumerable<GetHotelDto>>> GetHotelsAsync();
        Task<ICustomResult> UpdateHotelAsync(UpdateHotelDto hotelDto);
    }
}