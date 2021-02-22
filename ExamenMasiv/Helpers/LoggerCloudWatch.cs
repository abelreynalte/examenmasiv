using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMasiv.Helpers
{
    public class LoggerCloudWatch
    {
        private static Logger _logger;
        public LoggerCloudWatch()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public void RegisterLogFatal(Exception ex, Guid identifier)
        {
            var log = new LogEventInfo(LogLevel.Fatal, "", "")
            {
                Message = ex.Message,
                Exception = ex
            };

            log.Properties.Add("idlog", identifier.ToString());
            log.Properties.Add("methodName", $"{ex.TargetSite.DeclaringType?.FullName}.{ex.TargetSite.Name}");

            _logger.Fatal(log);
        }
    }
}
