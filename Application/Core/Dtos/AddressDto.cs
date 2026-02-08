namespace Core.Dtos;

public record AddressDto(
    int AddressTypeId,
    string AddressType,
    string Street,
    int AddressNumberId,
    (string, string) AddressNumber,
    string Colony,
    int CreditRequestNumber
) { }
