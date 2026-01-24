using Core.Dtos;
using Core.Models;

namespace Core.Mapping;

public static class UserMapping {

    public static ValidUserDto ToValidUserDto (this User usr, string token) => new (
        usr.UserName,
        usr.Profile,
        usr.FirsName,
        usr.LastName,
        token
    );

}
