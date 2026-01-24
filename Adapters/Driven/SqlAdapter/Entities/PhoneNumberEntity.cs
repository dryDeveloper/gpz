namespace SqlAdapter.Entities;

public class PhoneNumberEntity : Entity {
    public int Number { get; set; }
    public PhoneTypeEntity PhoneType { get; set; }
}

