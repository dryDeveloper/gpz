namespace Core.Models;

public class Address {
    public AddressType AddressType { get; set; }
    public string? Street { get; set; }
    public AddressNumber? Number { get; set; }
    public string Colon { get; set; } = "";
};
