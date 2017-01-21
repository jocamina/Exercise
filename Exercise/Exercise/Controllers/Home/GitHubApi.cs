using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

using Exercise.Models;

namespace Exercise.Controllers.Home
{
    public class GitHubApi
    {
        const string BASE_URL = "https://api.github.com";
        const string USERS = "users";
        const string REPOS = "repos";

        ApiClient m_apiClient;

        public GitHubApi()
        {
            m_apiClient = new ApiClient(BASE_URL);
        }

        public User GetUser(string userName)
        {
            var jsonResponse = m_apiClient.Get(GetUserAction(userName));

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        public IEnumerable<Repository> GetReposForUser(string userName)
        {
            var jsonResponse = m_apiClient.Get(GetReposAction(userName));

            var repos = JsonConvert.DeserializeObject<IEnumerable<Repository>>(jsonResponse);

            if (repos == null)
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