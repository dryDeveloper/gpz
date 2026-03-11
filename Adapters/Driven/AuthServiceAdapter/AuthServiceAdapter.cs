using Ports.Driven;
using SqlRepositoryAdapter.Mappers;
using SqlRepositoryAdapter.Entities;

namespace AuthServiceAdapter;

public class AuthServiceAdapter(IRepositoryPort<UserEntity> repo, IAuthToken token) : IAuthServicePort {

    public async Task<(bool valid, object payload)> DoAuthAsync(string usr, string pwd) {
        
        // TODO: hash pwd
        var thePwd = pwd;
        var user = await repo.FilterAsync(u => u.Password == pwd && u.Username == usr);

        var validUser = user.FirstOrDefault();

        if (validUser is not null)
            return (true, token.Generate(validUser.ToDto()));

        return (false, "invalid user or password");
    }

}
