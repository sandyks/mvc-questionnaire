using System;
using System.Web;
using System.Web.Mvc;

using Questionnaire.Models;

namespace Questionnaire.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index ( )
        {
            return View ( "Index", Question.FetchRandom ( ) );
        }
    }
}