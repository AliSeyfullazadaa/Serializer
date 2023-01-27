using Newtonsoft.Json;
using SerializationDeserialization;



async Task<List<User>> GetUsers()
{
    List<User> users = new List<User>();

    using (HttpClient httpClient = new HttpClient())
    {
        using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts"))
        {
            var content = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(content);

        }
    }
    return users.ToList();
}
var result = await GetUsers();
foreach (var item in result)
{
    Console.WriteLine($"Item id: {item.id} Item title:{item.title}  Item body:{item.body}");
    Console.WriteLine("------------------");
}


string filepath = @"C:\Users\User\Desktop\CodeAcademy\Seralize\SerializationDeserialization\SerializationDeserialization\Files\jsonFile.json";
var jsonString = JsonConvert.SerializeObject(result);

File.WriteAllText(filepath, jsonString);
