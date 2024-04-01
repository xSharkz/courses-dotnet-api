using System.ComponentModel.DataAnnotations;

namespace courses_dotnet_api.Src.DTOs;

public class UpdateStudentDto
{
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public required string Name { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }
}