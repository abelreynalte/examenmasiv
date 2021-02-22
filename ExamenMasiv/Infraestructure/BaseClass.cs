using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ExamenMasiv.Infraestructure
{
    public class BaseClass: Controller
    {
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
    }
}
