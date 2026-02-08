using Core.Dtos;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Mappers;

public static class PersonalReferenceMapper {

    public static PersonalReferenceEntity ToEntity(this PersonalReferenceDto dto, int clientId) => new () {
        Name = dto.Name,
        LastName = dto.LastName,
        PhoneNumberEntityId = dto.PhoneNumberId,
        PhoneNumber = dto.PhoneNumber.ToEntity(clientId),
        ClientCreditRequestEntityId = clientId
    };
}
