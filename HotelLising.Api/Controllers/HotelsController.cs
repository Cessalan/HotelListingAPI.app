using HotelLising.Api.Data;
using HotelLising.Api.DTOs.Hotel;
using HotelLising.Api.Results;
using HotelLising.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelLising.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ParentController
    {
        private readonly IHotelServices _services;

        public HotelsController(IHotelServices services)
        {
            _services = services;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<GetHotelDto>>>> GetHotels()
        {
            var result  = await _services.GetHotelsAsync();
            return HandleResult(result);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ICustomResult>> GetHotel(int id)
        {
            var result = await _services.GetHotelAsync(id);

            return HandleResult(result);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, UpdateHotelDto hotelDto)
        {
            if (id != hotelDto.Id)
            {
                return BadRequest();
            }


            await _services.UpdateHotelAsync(hotelDto);


            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ICustomResult>> PostHotel(CreateHotelDto hotelDto)
        {
           var result =  await _services.CreateHotel(hotelDto);

            return HandleResult(result);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ICustomResult>> DeleteHotel(DeleteHotelDTO deleteHotelDTO)
        {
            var result = await _services.DeleteHotelAsync(deleteHotelDTO);

            return HandleResult(result);
        }
    }
}
