using NLog;

namespace ExamGlobalApi.Services
{
    public class LogerService : ILogerService
    {
        private static NLog.ILogger loger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => loger.Debug(message);

        public void LogError(string message) => loger.Error(message);

        public void LogInfo(string message) => loger.Info(message);

        public void LogWarn(string message) => loger.Warn(message);
    }
}
