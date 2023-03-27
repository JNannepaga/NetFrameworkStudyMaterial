using System;

namespace AOPFramework
{
    public class MyException : Exception
    {
        public MyException()
        {

        }

        public MyException(string exceptionMessage)
            : base(exceptionMessage)
        {
            LogError(exceptionMessage);
        }

        public MyException(Exception exception)
            : base(exception.Message, exception.InnerException)
        {
            LogError(exception.Message);
            LogError(exception.InnerException?.Message);
        }

        public void LogError(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
    }
}
