using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string apiUrl = "<API_URL>"; // Replace with the actual API URL

        HttpResponseMessage response = await client.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response into an object
            var responseObject = JsonSerializer.Deserialize<ResponseObject>(jsonResponse);

            // Access the deserialized object's properties
            Console.WriteLine($"Name: {responseObject.Name}");
            Console.WriteLine($"Age: {responseObject.Age}");
        }
        else
        {
            Console.WriteLine($"Request failed with status code: {response.StatusCode}");
        }
    }
}

public class ResponseObject
{
    public string Name { get; set; }
    public int Age { get; set; }
}