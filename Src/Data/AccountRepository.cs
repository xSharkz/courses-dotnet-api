using System.Security.Cryptography;
using System.Text;
using courses_dotnet_api.Src.DTOs;
using courses_dotnet_api.Src.Interfaces;
using courses_dotnet_api.Src.Models;

namespace courses_dotnet_api.Src.Data;

public class AccountRepository : IAccountRepository
{
    private readonly DataContext _dataContext;

    public AccountRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return 0 < await _dataContext.SaveChangesAsync();
    }

    public async Task AddAccountAsync(RegisterStudentDto registerStudentDto)
    {
        using var hmac = new HMACSHA512();

        Student student =
            new()
            {
                Rut = registerStudentDto.Rut,
                Name = registerStudentDto.Name,
                Email = registerStudentDto.Email,
                PasswordHash = hmac.ComputeHash(
                    Encoding.UTF8.GetBytes(registerStudentDto.Password)
                ),
                PasswordSalt = hmac.Key
            };

        await _dataContext.Students.AddAsync(student);
    }
}
