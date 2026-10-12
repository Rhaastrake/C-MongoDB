using System.Text.Json;
using ProvaMongoDB.BLL;
using ProvaMongoDB.DAL;

class Program
{
    public static async Task Main(string[] args)
    {
        string json = File.ReadAllText("db.json");
        JsonElement root = JsonDocument.Parse(json).RootElement;

        Database.GetInstance(
            root.GetProperty("address").GetString(),
            root.GetProperty("port").GetString(),
            root.GetProperty("dbName").GetString(),
            root.GetProperty("dbCollection").GetString(),
            root.GetProperty("dbUser").GetString(),
            root.GetProperty("dbUserPassword").GetString()
        );

        StudentService service = new StudentService();

        try
        {
            List<Student> students = await service.GetAllAsync();

            Console.WriteLine("Studenti trovati: " + students.Count);

            foreach (Student student in students)
            {
                Console.WriteLine(student.Name + " " + student.Surname + " - " + student.Course + " (" + student.Age + ")");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}