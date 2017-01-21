using System.Web.Mvc;
using Newtonsoft.Json;
using Exercise.Models;

namespace Exercise.Controllers.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUser(Models.Filter filter)
        {
            var gitHubApi = new GitHubApi();

            var user = gitHubApi.GetUser(filter.InputValue);

            var topRepos = gitHubApi.GetTopResposStargazers(filter.InputValue);

            var response = new { User = user, Repos = topRepos };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}