using HtmlAgilityPack;
using NScrape;
using SearchEngine.UtilityClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace SearchEngine
{
    class Program
    {
        HtmlDocument htmlSnippet = new HtmlDocument();

        static void Main(string[] args)
        {          
            try
            {
                
                PerformSearch(args[0], args[1]);
            }
            catch (Exception ex)
            {
                LogError.AddLogError(ex.Message, ex.StackTrace);
            }
        }

        private static void PerformSearch(string param1, string param2)
        {
            try
            {
                string finalGoogleResult = string.Empty;
                string finalBingResult = string.Empty;

                var totalFinalParam1Result = 0;
                var totalFinalParam2Result = 0;

                var googleResults1 = GoogleSearchEngine.Search(param1);

                var bingResults1 = BingSearchEngine.Search(param1);

                var googleResults2 = GoogleSearchEngine.Search(param2); 
               
                var bingResults2 = BingSearchEngine.Search(param2);

                Console.WriteLine(param1 + " : " + "Google: " + googleResults1 + " Bing: " + bingResults1);
                Console.WriteLine(param2 + " : " + "Google: " + googleResults2 + " Bing: " + bingResults2);

                //Search Engine 1
                if (googleResults1 > googleResults2)
                {
                    finalGoogleResult = param1;
                    Console.WriteLine("Google Winner:" + param1);
                }
                else if (googleResults1 < googleResults2)
                {
                    finalGoogleResult = param2;
                    Console.WriteLine("Google Winner:" + param2);
                }

                //Search Engine 2
                if (bingResults1 > bingResults2)
                {
                    finalBingResult = param1;
                    Console.WriteLine("Bing Winner:" + param1);
                }
                else if (bingResults1 < bingResults2)
                {
                    finalBingResult = param2;
                    Console.WriteLine("Bing Winner:" + param2);
                }

                totalFinalParam1Result = Convert.ToInt32(googleResults1) + bingResults1;
                totalFinalParam2Result = Convert.ToInt32(googleResults2) + bingResults2;

                //Total Winner
                if (totalFinalParam1Result > totalFinalParam2Result)
                {
                    Console.WriteLine("Total Winner:" + param1);
                }
                else if (totalFinalParam1Result < totalFinalParam2Result)
                {
                    Console.WriteLine("Total Winner:" + param2);
                }
            }
            catch (Exception ex)
            {
                LogError.AddLogError(ex.Message, ex.StackTrace);
            }

            Console.Read();
        }
    }
}

