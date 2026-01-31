namespace SqlRepositoryAdapter.Entities;

public class PhoneNumberEntity : Entity {
    public int Number { get; set; }

    public int PhoneTypeEntityId { get; set; }
    public PhoneTypeEntity? PhoneType { get; set; }

    public int? ClientCreditRequestEntityId { get; set; }
    public ClientCreditRequestEntity? ClientCreditRequestEntity { get; set; }
}

