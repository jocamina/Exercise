using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Exercise.Models;
using Exercise.Models.Api;
using System.IO;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        const string DUMY_USER_RESPONSE = @"../../DummyJson/userResponse.js";
        const string DUMY_REPO_RESPONSE = @"../../DummyJson/repoResponse.js";
        const string DUMMY_URL = "https://dummy.url.com";
        const string DUMMY_USER = "defunkt";        

        [TestMethod]
        public void TestBaseJsonRequestExpectSuccess()
        {
            // Arrange
            var apiClient = Substitute.For<IApiClient>();
            string fakeUserResponse = File.ReadAllText(DUMY_USER_RESPONSE);
            apiClient.Get(DUMMY_URL).Returns(fakeUserResponse);

            // Act
            var response = apiClient.Get(DUMMY_URL);

            // Assert
            Assert.IsTrue(response == fakeUserResponse);
        }

        [TestMethod]
        [ExpectedException(typeof(NullBaseUrlException))]
        public void TestNullBaseUrlExpectException()
        {
            // Arrange
            var apiClientFactory = new ApiClientFactory();

            // Act
            var apiClient = apiClientFactory.CreateRestApiClient(string.Empty);
        }

        [TestMethod]
        public void TestParseUserExpectSuccess()
        {
            // Arrange
            var apiClient = Substitute.For<IApiClient>();
            string fakeUserResponse = File.ReadAllText(DUMY_USER_RESPONSE);
            apiClient.Get(null).ReturnsForAnyArgs(fakeUserResponse);

            var apiClientFactory = Substitute.For<AbstractApiClientFactory>();
            apiClientFactory.CreateRestApiClient(null).ReturnsForAnyArgs(apiClient);            

            var gitHubRepo = new GitHubApi(apiClientFactory);

            var mockUser = new User()
            {
                Id = 2,
                Login = "defunkt",
                Name = "Chris Wanstrath",
                AvatarUrl = "https://avatars.githubusercontent.com/u/2?v=3",
                Location = "San Francisco"
            };
            
            // Act
            var user = gitHubRepo.GetUser(DUMMY_USER);

            // Assert
            var equal = mockUser.Equals(user);
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestParseReposExpectSuccess()
        {
            // Arrange
            var apiClient = Substitute.For<IApiClient>();
            string dummyRepoResponse = File.ReadAllText(DUMY_REPO_RESPONSE);
            apiClient.Get(null).ReturnsForAnyArgs(dummyRepoResponse);

            var apiClientFactory = Substitute.For<AbstractApiClientFactory>();
            apiClientFactory.CreateRestApiClient(null).ReturnsForAnyArgs(apiClient);

            var gitHubRepo = new GitHubApi(apiClientFactory);

            var mockRepo = new Repository()
            {
                Id = 1861402,
                Name = "ace",
                FullName = "defunkt/ace",
                StargazersCount = 11
            };

            // Act
            var repos = gitHubRepo.GetTopResposStargazers(DUMMY_USER);

            // Assert
            var equal = mockRepo.Equals(repos.First());
            Assert.IsTrue(equal);
        }
    }
}
