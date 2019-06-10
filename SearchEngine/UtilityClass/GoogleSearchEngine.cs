using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System;

namespace SearchEngine.UtilityClass
{
    class GoogleSearchEngine
    {
        private static string apiKey = ResourceFile.GoogleApiKey;
        private static string searchEngineId = ResourceFile.GoogleSearchEngineId;

        public static CustomsearchService Service = new CustomsearchService(
            new BaseClientService.Initializer
            {
                ApplicationName = ResourceFile.ProjectName,
                ApiKey = apiKey,
            });

        public static long? Search(string query)
        {
            try
            {
                CseResource.ListRequest listRequest = Service.Cse.List(query);
                listRequest.Cx = searchEngineId;
                Search search = listRequest.Execute();
                var totalResult = search.SearchInformation.TotalResults;
                return totalResult;
            }
            catch (Exception ex)
            {
                LogError.AddLogError(ex.Message, ex.StackTrace);
                return -1;
            }
        }
    }
}
