using RestSharp;

namespace Exercise.Controllers.Home
{
    public class ApiClient
    {
        IRestClient m_restClient;

        public ApiClient(string baseUrl)
        {
            m_restClient = new RestClient(baseUrl);
        }        

        public string Get(string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            
            IRestResponse response = m_restClient.Execute(request);

            return response.Content;
        }
    }
}