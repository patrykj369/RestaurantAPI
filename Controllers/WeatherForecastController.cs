﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery]int numberResults, [FromBody]TemperatureRequest request)
        {
            if (numberResults > 0 && request.MinTemperature < request.MaxTemperature)
            {
                var result = _service.Get(numberResults, request.MinTemperature, request.MaxTemperature);
                HttpContext.Response.StatusCode = 200;
                return Ok(result);
            }
            else
            {
                return StatusCode(400);
            }
        }
        
    }
}
