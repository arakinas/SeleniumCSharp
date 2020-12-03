using Newtonsoft.Json;

namespace SeleniumNet5.Data.API.ExampleData
{
    public class Todos
    {
        [JsonProperty("userId")]
        public int userId { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("completed")]
        public bool completed { get; set; }
    }    
}