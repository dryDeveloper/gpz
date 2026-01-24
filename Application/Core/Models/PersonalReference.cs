namespace Core.Models;

public class PersonalReference {
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();
}
