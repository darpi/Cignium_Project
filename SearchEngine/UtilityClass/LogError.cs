using System;
using System.IO;

namespace SearchEngine.UtilityClass
{
    static class LogError
    {
        public static void AddLogError(string errorMessage, string errorStackTrace)
        {
            try
            {

                string filePath = ResourceFile.FileLogName;

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    var logTextDetail = "Message :" + errorMessage + "<br/>" +
                        Environment.NewLine + "StackTrace :" + errorStackTrace + "" +
                        Environment.NewLine + "Date :" + DateTime.Now.ToString();

                    var footer = Environment.NewLine + "-----------------------------------------------------------------------------" +
                        Environment.NewLine;

                    writer.WriteLine(logTextDetail);
                    writer.WriteLine(footer);

                    Console.WriteLine(logTextDetail);
                    Console.WriteLine(footer);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
