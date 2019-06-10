using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.UtilityClass
{
    public class BingCustomSearchResponse
    {
        public string type { get; set; }
        public WebPages webPages { get; set; }
    }

    public class WebPages
    {
        public string webSearchUrl { get; set; }
        public int totalEstimatedMatches { get; set; }
        public WebPage[] value { get; set; }
    }

    public class WebPage
    {
        public string name { get; set; }
        public string url { get; set; }
        public string displayUrl { get; set; }
        public string snippet { get; set; }
        public DateTime dateLastCrawled { get; set; }
        public string cachedPageUrl { get; set; }
    }

    class BingSearchEngine
    {
        private static string subscriptionKey = ResourceFile.BingSubscriptionKey;
        private static string customConfigId = ResourceFile.BingCustomConfigId;

        public static int Search(string query)
        {
            try
            {                
                var url = ResourceFile.BingUrl + "q=" + query + "&" + "customconfig=" + customConfigId;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add(ResourceFile.BingOcpApimSubscriptionKey, subscriptionKey);

                var httpResponseMessage = client.GetAsync(url).Result;
                var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                BingCustomSearchResponse response = JsonConvert.DeserializeObject<BingCustomSearchResponse>(responseContent);
                return response.webPages.totalEstimatedMatches;
            }
            catch (Exception ex)
            {
                LogError.AddLogError(ex.Message, ex.StackTrace);
                return -1;
            }
        }
    }
}
