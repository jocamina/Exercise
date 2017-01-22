
namespace Exercise.Models.Api
{
    public abstract class AbstractApiClientFactory
    {
        public abstract IApiClient CreateRestApiClient(string baseUrl);

        public abstract IApiClient CreateOctokitWrapper(string baseUrl);
    }
}