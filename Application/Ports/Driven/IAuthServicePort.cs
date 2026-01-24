namespace Ports.Driven;

public interface IAuthServicePort {
    (bool, object) DoAuth(string username, string password);
}
