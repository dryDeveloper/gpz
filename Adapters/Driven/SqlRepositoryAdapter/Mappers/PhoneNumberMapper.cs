using Core.Dtos;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Mappers;

public static class PhoneNumberMapper {

    public static PhoneNumberEntity ToEntity(this PhoneNumberDto dto, int clientId) => new () {
        Number = dto.Number,
        PhoneTypeEntityId = dto.PhoneTypeId,
        PhoneType = new PhoneTypeEntity { Description = dto.PhoneType },
        ClientCreditRequestEntityId = clientId
    };

}
