using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using SeleniumNet5.BaseTests;
using SeleniumNet5.RestSharp;
using Newtonsoft.Json;
using SeleniumNet5.Data.API.ExampleData;

namespace SeleniumNet5.Tests.API
{
    [TestFixture]
    public class ExampleAPITests : BaseRestTest
    {
        [Test]
        public void GetAllTodos_VerifyTodosCount()
        {
            RestClient client = RestSharpHandler.GetClient("https://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("todos", Method.GET);

            JsonDeserializer deserializer = new JsonDeserializer();

            var response = client.Execute(request);

            List<Todos> todos = JsonConvert.DeserializeObject<List<Todos>>(response.Content);

            Assert.AreEqual(200, todos.Count);

            RestSharpHandler.ValueShouldEqual(200, todos.Count);
        }

        [Test]
        public void GetSingleTodo_VerifyIDAndTitle()
        {
            RestClient client = RestSharpHandler.GetClient("https://jsonplaceholder.typicode.com/");

            RestRequest request = new RestRequest("todos/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            Todos todo = JsonConvert.DeserializeObject<Todos>(client.Execute(request).Content);

            RestSharpHandler.ValueShouldEqual(1, todo.id);
            RestSharpHandler.ValueShouldEqual("delectus aut autem", todo.title);

        }
    }
}
