
namespace AOPFramework.CustomInterceptors
{
    public static class InterceptingPipeline
    {
        private static readonly IInterceptor _loggerInterceptor;
        
        static InterceptingPipeline()
        {
            _loggerInterceptor = new LoggingInterceptor();
        }

        public static IInterceptor LoggerInterceptor => _loggerInterceptor; 
    }
}
