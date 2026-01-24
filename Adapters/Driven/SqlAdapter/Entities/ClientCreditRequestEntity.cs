namespace SqlAdapter.Entities;

public class ClientCreditRequestEntity : Entity {
    public ProjectTypeEntity ProjectType { get; set; }
    public ClientEntity Client { get; set; } = new ClientEntity();
    public RequestTypeEntity RequestType { get; set; }
    public DateTime CaptureDate { get; set; }
    public bool Urgent { get; set; }
    public int AsignedPhoneNumber { get; set; }
    public DateTime DateOfAsigment { get; set; }
    public AddressEntity[] Addresses { get; set; } = [];
    public PhoneNumberEntity[] PhoneNumbers { get; set; } = [];
    public PersonalReferenceEntity[] PersonalReferences { get; set; } = [];
}
