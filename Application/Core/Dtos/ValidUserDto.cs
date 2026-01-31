using Core.Models;

namespace Core.Dtos;

public record ValidUserDto(
    string UserName, 
    string Password,
    int Profile,
    string FirstName, 
    string LastName, 
    string Token
) : UserDto (
    UserName,
    Profile,
    FirstName,
    LastName
) {
    // public string Token { get; set; } = Token;
}
