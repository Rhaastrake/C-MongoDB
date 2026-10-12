using ProvaMongoDB.DAL;

namespace ProvaMongoDB.BLL;

public class StudentService
{
    private readonly StudentRepository _repository;

    public StudentService()
    {
        _repository = new StudentRepository();
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Student?> GetByIdAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Id mancante");
        }

        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Student student)
    {
        if (string.IsNullOrWhiteSpace(student.Name))
        {
            throw new ArgumentException("Il nome è obbligatorio");
        }

        if (string.IsNullOrWhiteSpace(student.Email) || !student.Email.Contains("@"))
        {
            throw new ArgumentException("Email non valida");
        }

        if (student.Age < 0 || student.Age > 120)
        {
            throw new ArgumentException("Età non valida");
        }

        await _repository.AddAsync(student);
    }

    public async Task<bool> ChangeCourseAsync(string id, string course)
    {
        if (string.IsNullOrWhiteSpace(course))
        {
            throw new ArgumentException("Corso mancante");
        }

        long modified = await _repository.UpdateCourseAsync(id, course);
        return modified > 0;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        long deleted = await _repository.DeleteAsync(id);
        return deleted > 0;
    }
}