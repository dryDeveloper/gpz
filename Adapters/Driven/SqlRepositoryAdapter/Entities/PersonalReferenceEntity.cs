namespace SqlRepositoryAdapter.Entities;

public class PersonalReferenceEntity : Entity {
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";

    public int PhoneNumberEntityId { get; set; }
    public PhoneNumberEntity? PhoneNumber { get; set; }

    public int? ClientCreditRequestEntityId { get; set; }
    public ClientCreditRequestEntity? ClientCreditRequestEntity { get; set; }
}

