using System;

namespace Exercise.Models.Api
{
    public class ApiClientFactory : AbstractApiClientFactory
    {
        public override IApiClient CreateRestApiClient(string baseUrl)
        {
            return new RestApiClient(baseUrl);
        }

        public override IApiClient CreateOctokitWrapper(string baseUrl)
        {
            throw new NotImplementedException("Not implemented yet, just for demo purposes.");
        }
    }
}