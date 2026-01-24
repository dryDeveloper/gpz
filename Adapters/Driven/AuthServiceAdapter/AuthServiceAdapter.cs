using Core.Mapping;
using Ports.Driven;

namespace Adapters.Driven.AuthServiceAdapter;

public class AuthServiceAdapter(ISqlPort dbCtx, IAuthToken token) : IAuthServicePort {

    public (bool, object) DoAuth(string usr, string pwd) {
        // Call SQLAdapter and fetch username 
        var user = dbCtx.GetUser(usr, pwd);

        if (user is not null)
            return (true, user.ToValidUserDto(token.Generate()));

        return (false, "invalid user or password");
    }

}
