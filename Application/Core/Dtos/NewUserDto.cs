namespace Core.Dtos;

public record NewUserDto(
    string UserName,
    string Password,
    string FirstName,
    string LastName,
    int Profile
) : UserDto (
    UserName,
    Profile,
    FirstName,
    LastName
);
