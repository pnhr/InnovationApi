namespace Innovation.Api.Util
{
    public static class Exten
    {
        public static void LogAppActivityInformation(this ILogger logger, string message)
        {
            logger.LogInformation($"InnovationApp : {message}");
        }
    }
}
