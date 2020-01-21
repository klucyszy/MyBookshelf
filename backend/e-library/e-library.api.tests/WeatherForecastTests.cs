using e_library.api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace e_library.api.tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void GetWeatherForecast_returns_results()
        {
            //arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            //act
            IEnumerable<WeatherForecast> result = controller.Get();

            //assert
            result.Should().HaveCount(5);

        }

        [Fact]
        public void GetWeatherForecast_for_day_returns_badrequest_when_model_not_valid()
        {
            //arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);
            controller.ModelState.AddModelError("day", "required");

            //act
            var result = controller.Get(1);

            //assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
