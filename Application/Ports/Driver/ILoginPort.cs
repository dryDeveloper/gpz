namespace Ports.Driver;

public interface ILoginPort {
    void LoginRequest(string username, string password);
}
