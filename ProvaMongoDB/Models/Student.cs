using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProvaMongoDB;

[BsonIgnoreExtraElements]
public class Studente
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("nome")]
    public string Nome { get; set; } = "";

    [BsonElement("cognome")]
    public string Cognome { get; set; } = "";

    [BsonElement("email")]
    public string Email { get; set; } = "";

    [BsonElement("eta")]
    public int Eta { get; set; }

    [BsonElement("corso")]
    public string Corso { get; set; } = "";

    [BsonElement("citta")]
    public string Citta { get; set; } = "";
}