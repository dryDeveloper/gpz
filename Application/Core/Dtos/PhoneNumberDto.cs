namespace Core.Dtos;

public record PhoneNumberDto(
    int Number,
    int PhoneTypeId,
    string PhoneType,
    ClientDto Client
){}
