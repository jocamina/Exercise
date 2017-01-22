using System;
using System.Web.Mvc;
using Exercise.Models.Api;

namespace Exercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        
        public JsonResult GetUser(Models.Filter filter)
        {
            try
            {
                var repoApiFactory = new RepoApiFactory();

                var gitHubApi = repoApiFactory.CreateGitHubRepo();

                var user = gitHubApi.GetUser(filter.InputValue);

                var topRepos = gitHubApi.GetTopResposStargazers(filter.InputValue);

                var response = new { User = user, Repos = topRepos };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                var response = new { Err = "Error retrieving user." };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }        
    }
}