using System.Collections.Generic;

namespace Exercise.Models.Api
{
    public interface IRepoApi
    {
        User GetUser(string userName);

        IEnumerable<Repository> GetTopResposStargazers(string userName, int topN = 5);
    }
}
