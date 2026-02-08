using Core.Dtos;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Mappers;

public static class AddressMapper {

    public static AddressEntity ToEntity(this AddressDto dto, int ClientId) => new () {
            AddressTypeEntityId = dto.AddressNumberId,
            AddressType = new AddressTypeEntity { Description = dto.AddressType },
            AddressNumberEntityId = dto.AddressNumberId,
            Number = new AddressNumberEntity { Exterior = dto.AddressNumber.Item1, Interior = dto.AddressNumber.Item2 },
            Street = dto.Street,
            Colony = dto.Colony,
            ClientCreditRequestEntityId = ClientId
    };
}
