using MongoDB.Driver;
using MongoDbDemo;

string connectionString = "mongodb://localhost:27017";
string databaseName = "simple_db";
string collectionName = "StudentRecord";

var Client = new MongoClient(connectionString);
IMongoDatabase db = Client.GetDatabase(databaseName);
var collection = db.GetCollection<Model>(collectionName);

var person1 = new Model { FirstName = "Deeksha", LastName = "Ramdhas", Age = 24};
await collection.InsertOneAsync(person1);
var person2 = new Model { FirstName = "Srujan", LastName = "Ramdhas", Age = 19};
await collection.InsertOneAsync(person2);

var results = await collection.FindAsync(_ => true);

foreach (var result in results.ToList())
{
    Console.WriteLine(value:$"{result.Id}: {result.FirstName} {result.LastName} {result.Age} ");
}

