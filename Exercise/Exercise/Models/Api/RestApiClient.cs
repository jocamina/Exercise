using RestSharp;

namespace Exercise.Models.Api
{
    public class RestApiClient : IApiClient
    {
        IRestClient m_restClient;

        public RestApiClient(string baseUrl)
        {
            CheckUrl(baseUrl);

            m_restClient = new RestClient(baseUrl);
        }

        private void CheckUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new NullBaseUrlException("Base url cannot be null.");
            }
        }

        public string Get(string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            
            var response = m_restClient.Execute(request);

            return response.Content;
        }
    }
}