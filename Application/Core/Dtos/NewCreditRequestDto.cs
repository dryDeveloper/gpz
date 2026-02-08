namespace Core.Dtos;

public record NewCreditRequestDto(
    int RequestNumber,
    int ProjectTypeId,
    string ProjectType,
    int ClientId,
    ClientDto Client,
    int RequestTypeId,
    string RequestType,
    DateTime CaptureDate,
    bool Urgent,
    int AssignedPhoneNumber,
    DateTime DateOfAssigment,
    IEnumerable<AddressDto> Addresses,
    IEnumerable<PhoneNumberDto> PhoneNumbers,
    IEnumerable<PersonalReferenceDto> PersonalReferences
) { }
