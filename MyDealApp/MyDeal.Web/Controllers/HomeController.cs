using System.Web.Mvc;
using System.IO;
using MyDeal.Web.ActionFilters;
using MyDeal.Web.Helper;

namespace MyDeal.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ParameterValidator]
        [HttpGet]
        public string GetShorterURL(string longUrl)
        {
            var url = ControllerHelper.GenerateShortUrl(longUrl);

            return Request.Url.Scheme + "://" + Request.Url.Authority + "/" + url.ShortUrl;
        }

        public ActionResult RedirectToLong(string shortURL)
        {
            var url = ControllerHelper.GetLongUrl(shortURL);
            Response.StatusCode = 302;
            return Redirect(url.LongUrl);
        }

        [HttpPost]
        public void AddPassenger(string record)
        {
            using (StreamWriter file =
            new StreamWriter(Server.MapPath("/pnl.txt"), true))
            {
                file.WriteLine(record);
            }
        }
    }
}