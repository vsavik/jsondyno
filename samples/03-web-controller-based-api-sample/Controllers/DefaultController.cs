using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace Jsondyno.ControllerBasedApi.Controllers;

[ApiController]
public sealed class DefaultController : ControllerBase
{
    private readonly ILogger<DefaultController> _logger;

    public DefaultController(
        ILogger<DefaultController> logger)
    {
        _logger = logger;
    }

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
        try
        {
            string? originalObject = data?.ToString();
            string response = data is not null ?
                $"First name: {data.FirstName}, Last name: {data.LastName}"
                : "Input object is null";

            _logger.LogInformation("Original object: \n{0}\nResult: {1}", originalObject ?? "null", response);

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest($"Invalid input JSON data: {e}");
        }
    }
}