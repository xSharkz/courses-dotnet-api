using courses_dotnet_api.Src.Interfaces;
using courses_dotnet_api.Src.Models;
using Microsoft.AspNetCore.Mvc;

namespace courses_dotnet_api.Src.Controllers;

public class StudentController : BaseApiController
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpPost]
    public async Task<IResult> CreateStudent(Student student)
    {
        Student? result = await _studentRepository.GetStudentByRutAsync(student.Rut);

        if (result is not null)
            return TypedResults.BadRequest("Student already exists");

        await _studentRepository.AddStudentAsync(student);

        bool saveChanges = await _studentRepository.SaveChangesAsync();

        if (!saveChanges)
            return TypedResults.BadRequest("An error occurred while creating the student");

        return TypedResults.Ok("Student created successfully");
    }

    [HttpGet]
    public async Task<IResult> GetStudents()
    {
        IEnumerable<Student> result = await _studentRepository.GetStudentsAsync();

        return TypedResults.Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetStudentById(int id)
    {
        Student? result = await _studentRepository.GetStudentByIdAsync(id);
        if (result is null)
            return TypedResults.NotFound("Student not found");

        return TypedResults.Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateStudent(int id, Student student)
    {
        bool result = await _studentRepository.UpdateStudentByIdAsync(id, student);

        if (!result)
            return TypedResults.NotFound("Student not found");

        result = await _studentRepository.SaveChangesAsync();

        if (!result)
            return TypedResults.BadRequest("An error occurred while updating the student");

        return TypedResults.Ok("Student updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteStudent(int id)
    {
        bool result = await _studentRepository.DeleteStudentByIdAsync(id);

        if (!result)
            return TypedResults.NotFound("Student not found");

        result = await _studentRepository.SaveChangesAsync();

        if (!result)
            return TypedResults.BadRequest("An error occurred while deleting the student");

        return TypedResults.Ok("Student deleted successfully");
    }
}
