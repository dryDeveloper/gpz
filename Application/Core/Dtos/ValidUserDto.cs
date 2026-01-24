using Core.Models;

namespace Core.Dtos;

public class ValidUserDto(
    string UserName, 
    UserProfile Profile,
    string FirstName, 
    string LastName, 
    string Token
) : User (
    UserName,
    Profile,
    FirstName,
    LastName
) {
    public string Token { get; set; } = Token;
}
