using courses_dotnet_api.Src.Interfaces;
using courses_dotnet_api.Src.Models;

namespace courses_dotnet_api.Src.Data;

public class StudentRepository : IStudentRepository
{
    private readonly DataContext _dataContext;

    public StudentRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddStudentAsync(Student student)
    {
        throw new NotImplementedException();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Student?> GetStudentByRutAsync(string rut)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateStudentByIdAsync(int id, Student updateStudent)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteStudentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
