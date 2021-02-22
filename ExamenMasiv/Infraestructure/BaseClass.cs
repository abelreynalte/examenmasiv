using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net.Http;

namespace ExamenMasiv.Infraestructure
{
    public class BaseClass: Controller
    {
        private static Logger _logger;
        public BaseClass()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        protected HttpResponseMessage BadRequestResponse(OutJsonModel content)
        {
            var badrequest = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            badrequest.Content = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");

            return badrequest;
        }
        protected HttpResponseMessage OkRequestResponse(OutJsonModel content)
        {
            var badrequest = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            badrequest.Content = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");

            return badrequest;
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
