namespace SqlAdapter.Entities;

public class AddressEntity : Entity {
    public AddressTypeEntity AddressType { get; set; }
    public string? Street { get; set; }
    public AddressNumberEntity Number { get; set; } = new AddressNumberEntity();
    public string Colon { get; set; } = "";
}

