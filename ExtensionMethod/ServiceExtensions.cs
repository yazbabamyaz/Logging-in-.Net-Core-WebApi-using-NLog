using ExamGlobalApi.Services;

namespace ExamGlobalApi.ExtensionMethod
{
    //Service Register=>Extension Method
    public static class ServiceExtensions
    {
        public static void RegisterLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILogerService,LogerService>();
        }
    }
}
