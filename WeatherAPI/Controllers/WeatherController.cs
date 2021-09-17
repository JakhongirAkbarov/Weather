﻿using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherBL;
using WeatherBL.Interfaces;
using WeatherBL.Models;
using WeatherBL.Validators;
using WeatherDAL;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        [Route("GetWeather")]
        [HttpGet]
        public async Task<string> GetWeather(string city, [FromServices] IWeatherService service)
        {
            var response = await service.GetCurrentWeatherAsync(city);
            if (response.IsSuccess is false)
            {
                //log.Error(response.Error);

                return response.Error;
            }

            //log.Info($"The weather in {response.City} City right now is {response.Temperature}");

            return response.Temperature.ToString();
        }
    }
}
