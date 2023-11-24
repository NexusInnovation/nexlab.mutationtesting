using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MutationTestingExample.Controllers;
using MutationTestingExample.Services;
using NSubstitute;

namespace MutationTestingExample.Tests
{
    public class GivenACalculatorController
    {
        private readonly IFixture _fixture;
        private readonly CalculatorController _sut;
        public GivenACalculatorController()
        {
            _fixture = new Fixture();
            _fixture.Customize<BindingInfo>(c => c.OmitAutoProperties());
            _fixture.Customize(new AutoNSubstituteCustomization());
            _sut = _fixture.Create<CalculatorController>();
        }


        [Fact]
        public void WhenAdding()
        {
            var result = _sut.Add(2, 2);
            result.Should().Be(4);
        }

        [Fact]
        public void WhenMultiplying()
        {
            var result = _sut.Multiply(2, 2);
            result.Should().Be(4);
        }

        [Fact]
        public void WhenDividing()
        {
            var result = _sut.Divice(2, 2);
            result.Should().Be(1);
        }

        [Fact]
        public void IsOneDigit()
        {
            var result = _sut.IsOneDigit(4);
            result.Should().BeTrue();
        }
    }
}