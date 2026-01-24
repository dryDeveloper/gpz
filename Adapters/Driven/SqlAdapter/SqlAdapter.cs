using Core.Models;
using Ports.Driven;
using SqlAdapter.Entities;

namespace SqlAdapter;

public class SqlDbCtxAdapter(GpzDbContext dbCtx) : ISqlPort {

    // public UserDto GetUser(string usr, string pwd) {
    //
    //     return new (usr, UserProfile.SystemAdministrator, "Jesus", "Fuentes");
    // }

    // public Entities.UserDto[] AllUsers() => [.. dbCtx.Users];       

}
