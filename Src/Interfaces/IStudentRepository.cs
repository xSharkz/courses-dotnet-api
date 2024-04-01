using courses_dotnet_api.Src.DTOs;

namespace courses_dotnet_api.Src.Interfaces;

public interface IStudentRepository
{
    Task<bool> SaveChangesAsync();
    Task AddStudentAsync(CreateStudentDto createStudentDto);
    Task<StudentDto?> GetStudentByIdAsync(int id);
    Task<StudentDto?> GetStudentByRutAsync(string rut);
    Task<IEnumerable<StudentDto>> GetStudentsAsync();
    Task<bool> UpdateStudentByIdAsync(int id, UpdateStudentDto updateStudentDto);
    Task<bool> DeleteStudentByIdAsync(int id);
}
