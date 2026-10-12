using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProvaMongoDB.DAL;

[BsonIgnoreExtraElements]
public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = "";

    [BsonElement("surname")]
    public string Surname { get; set; } = "";

    [BsonElement("email")]
    public string Email { get; set; } = "";

    [BsonElement("age")]
    public int Age { get; set; }

    [BsonElement("course")]
    public string Course { get; set; } = "";

    [BsonElement("city")]
    public string City { get; set; } = "";
}