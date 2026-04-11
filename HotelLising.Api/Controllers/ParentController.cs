using HotelLising.Api.Results;
using Microsoft.AspNetCore.Mvc;

namespace HotelLising.Api.Controllers
{

    public abstract class ParentController : ControllerBase
    {
        public ActionResult HandleResult(ICustomResult result) 
        {
            return result.StatusCode switch
            {
                StatusCodes.Status200OK => Ok(result),
                StatusCodes.Status201Created => Ok(result),
                StatusCodes.Status202Accepted => Ok(result),
                StatusCodes.Status409Conflict => Conflict(result),
                StatusCodes.Status404NotFound=> NotFound(result),
                StatusCodes.Status400BadRequest => BadRequest(result),
                StatusCodes.Status500InternalServerError => StatusCode(500,result),
                _ => StatusCode(result.StatusCode, result)
            };
        }
    }
}
