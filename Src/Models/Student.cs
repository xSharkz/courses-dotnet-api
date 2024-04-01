namespace courses_dotnet_api.Src.Models;

public class Student
{
    public int Id { get; set; }
    public required string Rut { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
