namespace Core.Dtos;

public record PrintCreditRequestDto(
    int RequestNumber,
    string ProjectType,
    ClientDto Client,
    string RequestType,
    DateTime CaptureDate,
    bool Urgent,
    int AssignedPhoneNumber,
    DateTime DateOfAssigment,
    AddressDto[] Addresses,
    PhoneNumberDto[] PhoneNumbers
){}
