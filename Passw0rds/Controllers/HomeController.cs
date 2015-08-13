using System;
using System.Web.Mvc;

namespace Passw0rds.Controllers
{
    public class HomeController : Controller
    {
        [Route("~/")]
        public ActionResult Index()
        {          
            return View();
        }

        [Route("~/ouch")]
        public ActionResult Ouch()
        {
            throw new Exception();
        }
    }
}