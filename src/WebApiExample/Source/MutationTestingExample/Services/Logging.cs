namespace MutationTestingExample.Services
{
    public class Logging : ILogging
    {
        public void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");

        }
    }
}
