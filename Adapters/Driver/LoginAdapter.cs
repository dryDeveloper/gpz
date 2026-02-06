namespace Adapters.Driver;

public class LoginAdapter(IAuthServicePort authService) : ILoginPort {

    public void LoginRequest(string usr, string pwd) {
        var (isValid, response) = authService.DoAuth(usr, pwd);
        if (isValid)
            Console.WriteLine("Access Granted...");
        else Console.WriteLine("Invalid username or password");
    }

}
