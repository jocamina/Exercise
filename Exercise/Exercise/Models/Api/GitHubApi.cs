using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Exercise.Models.Api
{
    public class GitHubApi : IRepoApi
    {
        const string BASE_URL = "https://api.github.com";
        const string USERS = "users";
        const string REPOS = "repos";

        IApiClient m_apiClient;

        public GitHubApi(AbstractApiClientFactory apiClientFactory)
        {
            m_apiClient = apiClientFactory.CreateRestApiClient(BASE_URL);
        }

        public User GetUser(string userName)
        {
            var resourceFull = GetUserAction(userName);

            var jsonResponse = m_apiClient.Get(resourceFull);

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        public IEnumerable<Repository> GetReposForUser(string userName)
         {
            var jsonResponse = m_apiClient.Get(GetReposAction(userName));

            var repos = JsonConvert.DeserializeObject<IEnumerable<Repository>>(jsonResponse);

            if (repos != null)
            {
                return repos;
            }

            return new Repository[0];
        }

        public IEnumerable<Repository> GetTopResposStargazers(string userName, int topN = 5)
        {
            var repos = GetReposForUser(userName);            

            var sortedRepos = repos.OrderByDescending(repo => repo.StargazersCount);

            return sortedRepos.Take(topN);
        }

        private string GetUserAction(string userName)
        {
            return $"{USERS}/{userName}";
        }

        private string GetReposAction(string userName)
        {
            return $"{USERS}/{userName}/{REPOS}";
        }
    }

}