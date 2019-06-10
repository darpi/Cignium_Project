using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.UtilityClass
{
    static class LogError
    {
        public static void AddLogError(string errorMessage, string errorStackTrace)
        {
            try
            {
                string filePath = @"C:\SearchEngineLogError.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + errorMessage + "<br/>" + 
                        Environment.NewLine + "StackTrace :" + errorStackTrace + "" + 
                        Environment.NewLine + "Date :" + DateTime.Now.ToString());

                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + 
                        Environment.NewLine);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
