using System;

using Context = System.Web.HttpContext;

namespace Questionnaire.Models
{
    public class Person
    {
        public static string Name
        {
            get
            {
                return Context.Current.User.Identity.Name;
            }
        }
    }
}