using System;

namespace Exercise.Models.Api
{
    public class RepoApiFactory : AbstractRepoApiFactory
    {
        public override IRepoApi CreateBitBucketRepo()
        {
            throw new NotImplementedException("Not implemented yet, just demo purposes.");
        }

        public override IRepoApi CreateGitHubRepo()
        {
            AbstractApiClientFactory apiClientFactory = new ApiClientFactory();

            return new GitHubApi(apiClientFactory);
        }
    }
}