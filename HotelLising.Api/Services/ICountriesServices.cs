using HotelLising.Api.DTOs.Country;
using HotelLising.Api.Results;

namespace HotelLising.Api.Services
{
    public interface ICountriesServices
    {
        Task<Result<object>> CreateCountryAsync(CreateCountryDto createCountryDto);
        Task<Result<object>> DeleteCountry(int id);
        Task<ICustomResult> GetCountriesAsync();
        Task<ICustomResult> GetCountry(int id);
        Task<Result<object>> UpdateCountry(int id, UpdateCountryDto updateCountryDto);
    }
}