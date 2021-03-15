using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetJsonData();

        }

        private async Task GetJsonData()
        {
            string response = await client.GetStringAsync("http://jsonplaceholder.typicode.com/todos");

            //Console.WriteLine(response);
            List<Todo> todo = JsonConvert.DeserializeObject<List<Todo>>(response);
            foreach(var item in todo)
            {
                Console.WriteLine(item.userId);
                Console.WriteLine(item.id);
                Console.WriteLine(item.title);
                Console.WriteLine(item.completed);
            }
        }
        class Todo
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public bool completed { get; set; }

        }
    }
}
