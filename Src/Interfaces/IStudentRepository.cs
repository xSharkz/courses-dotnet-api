using courses_dotnet_api.Src.Models;

namespace courses_dotnet_api.Src.Interfaces;

public interface IStudentRepository
{
    Task<bool> SaveChangesAsync();
    Task AddStudentAsync(Student student);
    Task<Student?> GetStudentByIdAsync(int id);
    Task<Student?> GetStudentByRutAsync(string rut);
    Task<IEnumerable<Student>> GetStudentsAsync();
    Task<bool> UpdateStudentByIdAsync(int id, Student updateStudent);
    Task<bool> DeleteStudentByIdAsync(int id);
}
