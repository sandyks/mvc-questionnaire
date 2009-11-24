using System;
using System.Configuration;

namespace Questionnaire.Models
{
    internal static class Configuration
    {
        internal static string DataStoreName
        {
            get { return ConfigurationSettings.AppSettings[ "DataStoreName" ]; }
        }

        internal static int NumberOfQuestionsToDisplay
        {
            get
            {
                int result = 0;
                int.TryParse (
                    ConfigurationSettings.AppSettings[ "NumberOfQuestionsToDisplay" ],
                    out result );
                return result;
            }
        }
    }
}
