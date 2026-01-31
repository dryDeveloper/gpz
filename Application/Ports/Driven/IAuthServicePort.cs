namespace Ports.Driven;

public interface IAuthServicePort {
    Task<(bool, object)> DoAuthAsync(string username, string password);
}
