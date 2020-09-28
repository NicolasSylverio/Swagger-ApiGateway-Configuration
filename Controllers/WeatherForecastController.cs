using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Swagger.Gateway.Configuration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swagger.Gateway.Configuration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Weather Forecast.
        /// </summary>
        /// <remarks>
        ///     Get default .Net Core Weather Forecast API.
        /// </remarks>
        /// <example>{}</example>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>IEnumerable Weather Forecast</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();
        }

        /// <summary>
        ///     Add new Summary
        /// </summary>
        /// <remarks>
        ///     Add new Summary in summary list in memory.
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>New Created Todo Item</returns>
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Summary>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Summary>> AddSummary([FromBody] Summary summary)
        {
            _logger.LogInformation($"Add Summary: {summary.SummaryName}");

            if (string.IsNullOrWhiteSpace(summary.SummaryName))
                return BadRequest();

            Summaries = Summaries.Append(summary.SummaryName).ToArray();

            if (Summaries.Count() == 0)
                return NoContent();

            return Created(nameof(AddSummary), Summaries.Select(x => new Summary(x)));
        }

        /// <summary>
        ///     Get All Summary
        /// </summary>
        /// <remarks>
        ///     Get all summary for list in memory.
        /// </remarks>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>IEnumerable Summary</returns>
        [HttpGet]
        [Route("Summary")]
        [ProducesResponseType(typeof(IEnumerable<Summary>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Summary>> GetSummary()
        {
            _logger.LogInformation($"Get Summary");

            if (Summaries.Count() == 0)
                return NoContent();

            return Ok(Summaries.Select(x => new Summary(x)));
        }
    }
}
