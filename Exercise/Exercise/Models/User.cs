using System;
using Newtonsoft.Json;

namespace Exercise.Models
{
    public class User : IEquatable<User>
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }       

        public bool Equals(User other)
        {
            bool areEqual = true;

            areEqual &= Id == other.Id;
            areEqual &= Login == other.Login;
            areEqual &= Name == other.Name;
            areEqual &= AvatarUrl == other.AvatarUrl;
            areEqual &= Location == other.Location;

            return areEqual;
        }
    }
}