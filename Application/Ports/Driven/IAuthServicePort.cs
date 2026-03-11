namespace Ports.Driven;

public interface IAuthServicePort {
    Task<(bool valid, object payload)> DoAuthAsync(string username, string password);
}
