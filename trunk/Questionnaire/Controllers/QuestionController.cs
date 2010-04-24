using System;
using System.Web;
using System.Web.Mvc;

using Questionnaire.Models;

namespace Questionnaire.Controllers
{
    [HandleError]
    public class QuestionController : Controller
    {
        Question question = new Question ( );

        [AcceptVerbs ( HttpVerbs.Post )]
        public ContentResult Validate ( FormCollection formCollection )
        {
            UpdateModel (
                question,
                new[] 
                    { 
                        "ID",
                        "SubmittedAnswerId"
                    }
            );
            return
                Content (
                    Question.IsCorrect (
                        question.SubmittedAnswerId,
                        question.Id ).ToString ( ) );
        }      
    }
}