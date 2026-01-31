namespace Core.Dtos;

public record UserDto(
    string UserName, 
    int Profile, 
    string FirstName, 
    string LastName
) {
    // public string UserName { get; set; } = usr;
    // public string Password { get; set; } = pwd;
    // public int Profile { get; set; } = profile;
    // public string FirstName { get; set; } = firstname;
    // public string LastName { get; set; } = lastname;
}
