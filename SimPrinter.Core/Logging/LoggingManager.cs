using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.Logging
{
    /// <summary>
    /// 로거관리자. 프로그램에서 사용할 로거를 설정한다.
    /// </summary>
    public static class LoggingManager
    {
        public static Logger Logger { get; }

        static LoggingManager()
        {
            Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(@"Logs\serilog.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 31)
                .CreateLogger();
        }
        
    }
}
