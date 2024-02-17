namespace ExamGlobalApi.Exceptions
{
    //Custom Exception
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
