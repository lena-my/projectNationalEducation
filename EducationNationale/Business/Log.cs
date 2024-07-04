using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace EducationNationale.Business
{
    public class Log
    {
        public const string LOG_PATH = "./bin/Debug/net8.0/logs.json";

        public void LogAction(string action)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {action}";

            Directory.CreateDirectory(Path.GetDirectoryName(LOG_PATH)); // ensure the diectory exists

            using (StreamWriter writer = new StreamWriter(LOG_PATH, true)) // add the log to the file
            {
                writer.WriteLine(logEntry);
            }
        }
    }
}