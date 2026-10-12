using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using ProvaMongoDB;

JsonElement dbInfo = JsonDocument.Parse(File.ReadAllText("db.json")).RootElement;

Database db = Database.GetInstance(
    dbInfo.GetProperty("address").GetString(),
    dbInfo.GetProperty("port").GetString(),
    dbInfo.GetProperty("dbName").GetString(),
    dbInfo.GetProperty("dbCollection").GetString(),
    dbInfo.GetProperty("dbUser").GetString(),
    dbInfo.GetProperty("dbUserPassword").GetString()
);

MongoClientSettings settings = MongoClientSettings.FromConnectionString(db.GetConnectionString());
settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);

MongoClient client = new MongoClient(settings);
IMongoDatabase database = client.GetDatabase(db.DbName);
IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(db.DbCollection);

List<BsonDocument> results = collection.Find(new BsonDocument()).ToList();

PrintAllDocuments(results);

void PrintAllDocuments(List<BsonDocument> documents)
{
    foreach (BsonDocument document in results)
    {
        Console.WriteLine(document);
    }
}