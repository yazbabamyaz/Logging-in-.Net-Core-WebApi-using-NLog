namespace ExamGlobalApi.Services
{
    public interface ILogerService
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
