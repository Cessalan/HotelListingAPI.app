using HotelLising.Api.Data;
using HotelLising.Api.DTOs.Country;
using HotelLising.Api.Results;
using Microsoft.EntityFrameworkCore;

namespace HotelLising.Api.Services
{
    public class CountriesServices : ICountriesServices
    {
        private readonly HotelListingDBContext _context;

        public CountriesServices(HotelListingDBContext context)
        {
            _context = context;
        }

        public async Task<ICustomResult> GetCountriesAsync()
        {
            var countries = await _context.Countries.Select(c => new GetCountryDto(
              c.CountryId,
              c.Name,
              c.ShortName
             )).ToListAsync();

            return Result<IEnumerable<GetCountryDto>>.Ok(data: countries,
                                                         message: "country fetched successfuly");
        }

        public async Task<ICustomResult> GetCountry(int id)
        {
            var countryDto = await _context.Countries.Where(c => c.CountryId == id)
                                                     .Select(c => new GetCountryDto(
                                                          c.CountryId,
                                                          c.Name,
                                                          c.ShortName
                                                      )).FirstOrDefaultAsync();

            if (countryDto == null)
            {
                return Result<GetCountryDto>.NotFound("country not found");
            }

            return Result<GetCountryDto>.Ok(data: countryDto,
                                            message: "country fetched successufly");
        }

        public async Task<Result<object>> CreateCountryAsync(CreateCountryDto createCountryDto)
        {
            Country country = new Country()
            {
                Name = createCountryDto.Name,
                ShortName = createCountryDto.ShortName,
            };

            await _context.Countries.AddAsync(country);

            await _context.SaveChangesAsync();

            return Result<object>.CreatedAt("Country Create Sucessfully");
        }

        public async Task<Result<object>> UpdateCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id <= 0)
            {
                return Result<object>.BadRequest("Invalid id");
            }

            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return Result<object>.NotFound("Country not found");
            }

            country.Name = updateCountryDto.Name;
            country.ShortName = updateCountryDto.ShortName;

            await _context.SaveChangesAsync();

            return Result<object>.Ok(null, "country update sucessfuly");
        }

        public async Task<Result<object>> DeleteCountry(int id)
        {

            if (id <= 0)
            {
                return Result<object>.BadRequest("Invalid id");
            }

            var countryToDelete = await _context.Countries.FindAsync(id);

            if (countryToDelete == null)
            {
                return Result<object>.NotFound("Country was not found");
            }


            _context.Countries.Remove(countryToDelete);

            await _context.SaveChangesAsync();

            return Result<object>.Ok(null, "Country deleted sucessfully");
        }
    }
}
