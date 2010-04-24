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

        [AcceptVerbs( HttpVerbs.Post )]
        public ContentResult Send ( FormCollection formCollection )
        {
            string result = "Success";

            try
            {
                Message message = new Message();
                message.Send(
                    formCollection[ "personName" ],
                    int.Parse( formCollection[ "numberOfCorrect" ] ),
                    int.Parse( formCollection[ "numberOfIncorrect" ] ) );
            }
            catch ( Exception exception )
            {
                result = exception.Message;
            }

            return Content( result );
        } 
    }
}