using Microsoft.AspNetCore.Mvc;
using MutationTestingExample.Services;

namespace MutationTestingExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divice(int a, int b)
        {
            return a / b;
        }

        public bool IsOneDigit(int number)
        {
            return -9 <= number && number <= 9;
        }
    }
}