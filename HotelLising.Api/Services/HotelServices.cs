using HotelLising.Api.Data;
using HotelLising.Api.DTOs.Hotel;
using HotelLising.Api.Results;
using Microsoft.EntityFrameworkCore;

namespace HotelLising.Api.Services
{
    public class HotelServices : IHotelServices
    {
        private readonly HotelListingDBContext _context;

        public HotelServices(HotelListingDBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task<Result<IEnumerable<GetHotelDto>>> GetHotelsAsync()
        {
            var list = await _context.Hotels.Select(h => new GetHotelDto(
                h.Id,
                h.Name,
                h.Address,
                h.Rating,
                h.CountryId,
                h.Country!.Name
            )).ToListAsync();

            var result = Result<IEnumerable<GetHotelDto>>.Ok(data: list,
                                                             message: "hotel list fetched successfuly");
            return result;
        }

        public async Task<ICustomResult> GetHotelAsync(int hotelId)
        {
            var hotel = await _context.Hotels
               .Where(h => h.Id == hotelId)
               .Select(h => new GetHotelDto(
                   h.Id,
                   h.Name,
                   h.Address,
                   h.Rating,
                   h.CountryId,
                   h.Country!.Name
               )).FirstOrDefaultAsync();

            if (hotel == null)
            {
                return Result<object>.NotFound("No hotel found");
            }

            var result = Result<GetHotelDto?>.Ok(data: hotel,
                                                message: "hotel fetched successufly");
            return result;
        }

        public async Task<ICustomResult> UpdateHotelAsync(UpdateHotelDto hotelDto)
        {
            if (hotelDto.Id <= 0)
            {
                return Result<object>.BadRequest(message: "invalid id");
            }

            var dbHotel = await _context.Hotels.FindAsync(hotelDto.Id);

            if (dbHotel != null)
            {
                dbHotel.Name = hotelDto.Name;
                dbHotel.Address = hotelDto.Address;
                dbHotel.Rating = hotelDto.Rating;
                dbHotel.CountryId = hotelDto.CountryId;

                await _context.SaveChangesAsync();

                var result = Result<object>.Ok(data: null, message: "hotel update successfuly");

                return result;
            }

            return Result<object>.NotFound("Could not find hotel");
        }

        public async Task<ICustomResult> CreateHotel(CreateHotelDto hotelDto)
        {
            Hotel hotel = new()
            {
                Address = hotelDto.Address,
                Name = hotelDto.Name,
                Rating = hotelDto.Rating,
                CountryId = hotelDto.CountryId
            };

            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();

            var result = Result<object>.CreatedAt("Hotel create sucessfuly");

            return result;
        }

        public async Task<ICustomResult> DeleteHotelAsync(DeleteHotelDTO deleteHotelDTO)
        {
            if (deleteHotelDTO.Id <= 0)
            {
                return Result<object>.BadRequest("Invalid id");
            }

            var hotelToDelete = await _context.Hotels.FindAsync(deleteHotelDTO.Id);

            if (hotelToDelete == null)
            {
                return Result<object>.NotFound("Could not find hotel");
            }

            _context.Hotels.Remove(hotelToDelete);
            await _context.SaveChangesAsync();

            return Result<object>.Ok(data: null, "Delete successfly");
        }
    }

}
