namespace Core.Models;

public class User(string userName, UserProfile profile, string firsName, string lastName) { 
    public string UserName { get; set; } = userName;
    public UserProfile Profile { get; set; } = profile;
    public string FirsName { get; set; } = firsName;
    public string LastName { get; set; } = lastName;
};
