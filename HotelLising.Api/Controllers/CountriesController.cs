using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelLising.Api.Data;
using HotelLising.Api.Services;
using HotelLising.Api.DTOs.Country;
using HotelLising.Api.Results;

namespace HotelLising.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ParentController
{
    private readonly ICountriesServices _services;

    public CountriesController(ICountriesServices services) 
    {
        _services = services;
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetCountryDto>>>> GetCountries()
    {
        var result = await _services.GetCountriesAsync();

        return HandleResult(result);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetCountryDto>>> GetCountry(int id)
    {
        var result = await _services.GetCountry(id);

        return HandleResult(result);
    }

    // PUT: api/Countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<ActionResult<Result<object>>> PutCountry(int id, UpdateCountryDto updateCountryDto)
    {
        var result = await _services.UpdateCountry(id,updateCountryDto);

        return HandleResult(result);
    }

    // POST: api/Countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CreateCountryDto>> PostCountry(CreateCountryDto createCountryDto)
    {
        var result = await _services.CreateCountryAsync(createCountryDto);

        return HandleResult(result);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> DeleteCountry(int id)
    {
        var result = await _services.DeleteCountry(id);

        return HandleResult(result);
    }
}
