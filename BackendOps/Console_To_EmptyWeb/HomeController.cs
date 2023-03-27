using System.Web.Http;

namespace Console_To_EmptyWeb
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