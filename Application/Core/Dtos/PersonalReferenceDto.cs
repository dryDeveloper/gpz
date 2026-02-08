namespace Core.Dtos;

public record PersonalReferenceDto(
    string Name,
    string LastName,
    int PhoneNumberId,
    PhoneNumberDto PhoneNumber,
    int ClientId
){}
