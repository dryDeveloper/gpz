namespace SqlAdapter.Entities;

public class PersonalReferenceEntity : Entity {
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public PhoneNumberEntity PhoneNumber { get; set; } = new PhoneNumberEntity();
}

