
namespace Exercise.Models.Api
{
    public abstract class AbstractRepoApiFactory
    {
        public abstract IRepoApi CreateGitHubRepo();

        public abstract IRepoApi CreateBitBucketRepo();
    }
}