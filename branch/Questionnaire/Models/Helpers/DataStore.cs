using System;
using System.IO;

using Context = System.Web.HttpContext;

namespace Questionnaire.Models
{
    internal class DataStore
    {
        internal static string Fetch ( )
        {
            string result = string.Empty;

            string dataStoreFileSystemPath =
                Context.Current.Request.PhysicalApplicationPath
                + @"Models\DataStores\" 
                + Configuration.DataStoreName
                + @".txt";
            StreamReader streamReader = null;
            try
            {
                streamReader = 
                    new StreamReader ( dataStoreFileSystemPath );
                result = streamReader.ReadToEnd ( );
            }
            finally
            {
                streamReader.Close ( );
            }

            return result;
        }
    }
}