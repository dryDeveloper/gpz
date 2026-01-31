namespace SqlRepositoryAdapter.Entities;

public class ClientCreditRequestEntity : Entity {

    public int ProjectTypeEntityId { get; set; }
    public ProjectTypeEntity? ProjectType { get; set; }

    public int ClientEntityId { get; set; }
    public ClientEntity? Client { get; set; }

    public int RequestTypeEntityId { get; set; }
    public RequestTypeEntity? RequestType { get; set; }

    public DateTime CaptureDate { get; set; }
    public bool Urgent { get; set; }
    public int AssignedPhoneNumber { get; set; }
    public DateTime DateOfAssigment { get; set; }

    public IEnumerable<AddressEntity>? Addresses { get; set; }

    public IEnumerable<PhoneNumberEntity>? PhoneNumbers { get; set; }

    public IEnumerable<PersonalReferenceEntity>? PersonalReferences { get; set; }
}
