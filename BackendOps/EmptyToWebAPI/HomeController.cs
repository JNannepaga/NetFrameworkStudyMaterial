using System.Web.Http;

namespace EmptyToWebAPI
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}