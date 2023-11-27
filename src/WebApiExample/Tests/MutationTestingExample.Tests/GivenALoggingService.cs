using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MutationTestingExample.Controllers;
using MutationTestingExample.Services;

namespace MutationTestingExample.Tests
{
    public class GivenALoggingService
    {
        private readonly IFixture _fixture;
        private readonly Logging _sut;
        public GivenALoggingService()
        {
            _fixture = new Fixture();
            _sut = _fixture.Create<Logging>();
        }

        [Fact]
        public void WhenLoggingNull_ThenAnExceptionIsThrown()
        {
            var act = () => _sut.Log(null);
            act.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'message')");
        }

        [Fact]
        public void WhenLoggingAMessage_NothingHappens()
        {
            _sut.Log(_fixture.Create<string>());
        }
    }
}