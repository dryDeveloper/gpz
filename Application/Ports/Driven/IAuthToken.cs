using Core.Dtos;

namespace Ports.Driven;

public interface IAuthToken {
    string Generate(UserDto user);
}
