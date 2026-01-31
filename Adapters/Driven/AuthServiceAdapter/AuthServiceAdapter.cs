using Ports.Driven;
using SqlRepositoryAdapter.Mappers;
using SqlRepositoryAdapter.Entities;

namespace AuthServiceAdapter;

public class AuthServiceAdapter(IRepositoryPort<UserEntity> repo, IAuthToken token) : IAuthServicePort {

    public async Task<(bool, object)> DoAuthAsync(string usr, string pwd) {
        
        // TODO: hash pwd
        var thePwd = pwd;
        var user = (UserEntity) await repo.FilterAsync(u => u.Password == pwd && u.Username == usr);

        if (user is not null)
            return (true, user.ToDto(token.Generate()));

        return (false, "invalid user or password");
    }

}
