using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace EducationNationale.Business
{
    public static class Logger
    {
        public const string LOG_PATH = "./bin/Debug/net8.0/logs.json";
        public static void ConfigurationLogs()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(LOG_PATH, LogEventLevel.Information)
                .WriteTo.Console()
                .CreateLogger();
        }

    }
}