
using System;
using System.IO;

namespace EmployeeApi.DAL
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger(); // Eager
        private readonly string _logFilePath = "log.txt";

        private Logger() { }

        public static Logger Instance => _instance;

        public void Log(string message)
        {
            var logMessage = $"{DateTime.UtcNow}: {message}{Environment.NewLine}";
            File.AppendAllText(_logFilePath, logMessage);
        }
    }
}