using System.Text.Json;
using Jsondyno;

string json = """
    {
        "FirstName": "John",
        "LastName": "Doe",
        "DataList": [42, "item", null, { "X": 15.5 }],
        "Nums": [5, 6, 2]
    }
    """;

// Add instance of DynamicConverter to JsonSerializerOptions config
var opts = new JsonSerializerOptions
{
    Converters = { new DynamicConverter() }
};

// Deserialize to dynamic variable
dynamic rootObj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

// Access json object property by member name
string firstName = rootObj.FirstName;
Console.WriteLine(firstName); // Output: John

// Access json object property by key
string lastName = rootObj["LastName"];
Console.WriteLine(lastName); // Output: Doe

// Deserialize object to Dictionary<string, dynamic>
Dictionary<string, dynamic> rootDict = rootObj;
string keys = String.Join(", ", rootDict.Keys.Where(x => x.Contains("Name")));
Console.WriteLine(keys); // Output: FirstName, LastName

// Deserialize object to target type User
User rootUser = rootObj;
Console.WriteLine(rootUser); // Output: User { FirstName = John, LastName = Doe }

// Get length of json array
int length = rootObj.DataList.Length;
Console.WriteLine(length); // Output: 4

// Get json array item by index
int item0 = rootObj.DataList[0];
Console.WriteLine(item0); // Output: 42

string item1 = rootObj.DataList[1];
Console.WriteLine(item1); // Output: item

string? item2 = rootObj.DataList[2];
Console.WriteLine(item2 ?? "<null>"); // Output: <null>

// Access child object property
double x = rootObj.DataList[3].X;
Console.WriteLine(x.ToString("0.00", CultureInfo.InvariantCulture)); // Output: 15.50

// Deserialize array of numbers to List<int>
List<int> numbers = rootObj.Nums;
Console.WriteLine(String.Join(", ", numbers)); // Output: 5, 6, 2

// Use foreach keyword against array
foreach (int i in rootObj.Nums)
{
    Console.Write($"{i} "); // Output: 5 6 2
}

Console.WriteLine();

public sealed record User(string? FirstName, string? LastName);