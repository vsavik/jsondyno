using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace Jsondyno.ControllerBasedApi.Controllers;

[ApiController]
public sealed class DefaultController : ControllerBase
{
    [HttpGet]
    [Route("/")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Index() => LocalRedirectPermanent("~/swagger");

    [HttpPost]
    [Route("/")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Text.Plain)]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Submit([FromBody] dynamic? data)
    {
        string response = data is not null ?
            $"First name: {data.FirstName}, Last name: {data.LastName}"
            : "Input object is null";

        return Ok(response);
    }
}