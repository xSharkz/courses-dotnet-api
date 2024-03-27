using courses_dotnet_api.Src.Interfaces;
using courses_dotnet_api.Src.Models;
using Microsoft.EntityFrameworkCore;

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
        return 0 < await _dataContext.SaveChangesAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        await _dataContext.Students.AddAsync(student);
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _dataContext.Students.FindAsync(id);
    }

    public async Task<Student?> GetStudentByRutAsync(string rut)
    {
        return await _dataContext.Students.FirstOrDefaultAsync(x => x.Rut == rut);
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return await _dataContext.Students.ToListAsync();
    }

    public async Task<bool> UpdateStudentByIdAsync(int id, Student updateStudent)
    {
        var student = await GetStudentByIdAsync(id);

        if (student is null)
            return false;

        student.Name = updateStudent.Name;
        student.Email = updateStudent.Email;

        return true;
    }

    public async Task<bool> DeleteStudentByIdAsync(int id)
    {
        var student = await GetStudentByIdAsync(id);

        if (student is null)
            return false;

        _dataContext.Students.Remove(student);

        return true;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsByName(string name)
    {
        return await _dataContext.Students.Where(x => x.Name.Contains(name)).ToListAsync();
    }
}
