using System;
using Newtonsoft.Json;

namespace Exercise.Models
{
    public class Repository : IEquatable<Repository>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("stargazers_count")]
        public int StargazersCount { get; set; }

        public bool Equals(Repository other)
        {
            bool areEqual = true;

            areEqual &= Id == other.Id;
            areEqual &= Name == other.Name;
            areEqual &= FullName == other.FullName;
            areEqual &= StargazersCount == other.StargazersCount;            

            return areEqual;
        }
    }
}