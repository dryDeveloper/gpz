using Core.Dtos;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Mappers;

public static class CreditRequestMapper {

    public static ClientCreditRequestEntity ToEntity(this NewCreditRequestDto dto) => new() {
        RequestNumber = dto.RequestNumber,
        ProjectTypeEntityId = dto.ProjectTypeId,
        ProjectType = new ProjectTypeEntity { Description = dto.ProjectType },
        ClientEntityId = dto.ClientId,
        Client = dto.Client.ToEntity(),
        RequestTypeEntityId = dto.RequestTypeId,
        RequestType = new RequestTypeEntity { Description = dto.RequestType },
        DateOfAssigment = dto.DateOfAssigment,
        CaptureDate = dto.CaptureDate,
        Addresses = dto.Addresses.Select(a => a.ToEntity(dto.ClientId)),
        PhoneNumbers = dto.PhoneNumbers.Select(p => p.ToEntity(dto.ClientId)),
        PersonalReferences = dto.PersonalReferences.Select(r => r.ToEntity(dto.ClientId))
    };
}
