using Core.Dtos;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Mappers;

public static class UserMapper {

    public static ValidUserDto ToDto(this UserEntity entity, string token) => new (
        entity.Username,
        entity.Password,
        entity.UserProfileId,
        entity.Firstname,
        entity.Lastname,
        token
    );

    public static UserDto ToDto(this UserEntity entity) => new (
        entity.Username,
        entity.UserProfileId,
        entity.Firstname,
        entity.Lastname
    );

    public static UserEntity ToEntity(this NewUserDto dto) => new (
        dto.UserName,
        dto.Password,
        dto.FirstName,
        dto.LastName,
        dto.Profile
    );

}
