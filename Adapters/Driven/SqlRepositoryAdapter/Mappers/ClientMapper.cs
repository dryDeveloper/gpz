using Core.Dtos;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Mappers;

public static class ClientMapper {

    public static ClientEntity ToEntity(this ClientDto dto) => new() {
        Name = dto.Name,
        LastName = dto.LastName,
        Rfc = dto.Rfc
    };
}
