using courses_dotnet_api.Src.DTOs;
using courses_dotnet_api.Src.Interfaces;
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
    public async Task<IResult> CreateStudent(CreateStudentDto createStudentDto)
    {
        StudentDto? student = await _studentRepository.GetStudentByRutAsync(createStudentDto.Rut);

        if (student is not null)
            return TypedResults.BadRequest($"The student with RUT {createStudentDto.Rut} already exists");

        await _studentRepository.AddStudentAsync(createStudentDto);

        bool saveChanges = await _studentRepository.SaveChangesAsync();

        if (!saveChanges)
            return TypedResults.BadRequest("An error occurred while creating the student");

        return TypedResults.Ok("Student created successfully");
    }

    [HttpGet]
    public async Task<IResult> GetStudents()
    {
        IEnumerable<StudentDto> students = await _studentRepository.GetStudentsAsync();

        return TypedResults.Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetStudentById(int id)
    {
        StudentDto? student = await _studentRepository.GetStudentByIdAsync(id);
        if (student is null)
            return TypedResults.NotFound("Student not found");

        return TypedResults.Ok(student);
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateStudent(int id, UpdateStudentDto updateStudentDto)
    {
        if (ModelState.IsValid is false)
            return TypedResults.BadRequest();
            
        bool result = await _studentRepository.UpdateStudentByIdAsync(id, updateStudentDto);

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
