using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MutationTestingExample.Controllers;
using MutationTestingExample.Services;
using NSubstitute;

namespace MutationTestingExample.Tests
{
    public class GivenAWeatherForecastController
    {
        private readonly IFixture _fixture;
        private readonly ILogging _loggingMock;
        private readonly WeatherForecastController _sut;
        public GivenAWeatherForecastController()
        {
            _fixture = new Fixture();
            _fixture.Customize<BindingInfo>(c => c.OmitAutoProperties());
            _fixture.Customize(new AutoNSubstituteCustomization());
            _loggingMock = _fixture.Freeze<ILogging>();
            _sut = _fixture.Create<WeatherForecastController>();
        }

        [Fact]
        public void WhenRequestingTheWeather_WeGetAnObjectBack()
        {
            var result = _sut.Get();
            result.Should().NotBeNull();
        }

        [Fact]
        public void WhenRequestingTheWeather_WeGetWeatherInformationBack()
        {
            var result = _sut.Get();
            result.Should().HaveCountGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void WhenRequestingTheWeather_WeShouldLogAMessage()
        {
            var result = _sut.Get();
            _loggingMock.Received().Log(Arg.Any<string>());
        }

        [Fact]
        public void WhenSendingLog()
        {
            _sut.SendLog("Test");
            _loggingMock.Received().Log(Arg.Any<string>());
        }
    }
}