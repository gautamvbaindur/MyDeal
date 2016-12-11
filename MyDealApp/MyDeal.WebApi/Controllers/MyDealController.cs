using MyDeal.WebApi.ControllerHelper;
using System.Web.Http;
using System.Web.Http.Cors;
using MyDeal.WebApi.Models;

namespace MyDeal.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("mydeal")]
    public class MyDealController : ApiController
    {
        private IControllerHelper _controllerHelper;

        public MyDealController(IControllerHelper controllerHelper)
        {
            _controllerHelper = controllerHelper;
        }

        [HttpGet]
        [Route("shorten")]
        public IHttpActionResult GetShortenedUrl(string longUrl)
        {
            return Json(_controllerHelper.GetShortenedUrl(longUrl));
        }

        [HttpPost]
        [Route("pnl")]
        public IHttpActionResult PassengerLocator([FromBody]PassengerLocator passengerList)
        {
            return Json(_controllerHelper.GetPassengers(passengerList));
        }
    }
}
