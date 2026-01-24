namespace Core.Models;

public class ClientCreditRequest {
    public ProjectType ProjectType { get; set; }
    public Client Client { get; set; } = new Client();
    public RequestType RequestType { get; set; }
    public DateTime CaptureDate { get; set; }
    public bool Urgent { get; set; }
    public int AsignedPhoneNumber { get; set; }
    public DateTime DateOfAsigment { get; set; }
    public Address[] Addresses { get; set; } = [];
    public PhoneNumber[] PhoneNumbers { get; set; } = [];
    public PersonalReference[] PersonalReferences { get; set; } = [];
}
