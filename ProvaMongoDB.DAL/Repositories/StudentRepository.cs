using MongoDB.Bson;
using MongoDB.Driver;

namespace ProvaMongoDB.DAL;

public class StudentRepository
{
    private readonly IMongoCollection<Student> _collection;

    public StudentRepository()
    {
        Database database = Database.GetInstance();

        MongoClientSettings settings = MongoClientSettings.FromConnectionString(database.GetConnectionString());
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);

        MongoClient client = new MongoClient(settings);
        IMongoDatabase db = client.GetDatabase(database.DbName);

        _collection = db.GetCollection<Student>(database.DbCollection);
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _collection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(string id)
    {
        FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(s => s.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task InsertAsync(Student student)
    {
        await _collection.InsertOneAsync(student);
    }

    public async Task<long> UpdateCourseAsync(string id, string course)
    {
        FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(s => s.Id, id);
        UpdateDefinition<Student> update = Builders<Student>.Update.Set(s => s.Course, course);

        UpdateResult result = await _collection.UpdateOneAsync(filter, update);
        return result.ModifiedCount;
    }

    public async Task<long> DeleteAsync(string id)
    {
        FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(s => s.Id, id);

        DeleteResult result = await _collection.DeleteOneAsync(filter);
        return result.DeletedCount;
    }
}