namespace SqlRepositoryAdapter.Entities;

public class AddressEntity : Entity {

    public int AddressTypeEntityId { get; set; }
    public AddressTypeEntity? AddressType { get; set; }

    public string? Street { get; set; }

    public int AddressNumberEntityId { get; set; }
    public AddressNumberEntity? Number { get; set; }

    public string? Colony { get; set; }

    public int? ClientCreditRequestEntityId { get; set; }
    public ClientCreditRequestEntity? ClientCreditRequestEntity { get; set; }
}

