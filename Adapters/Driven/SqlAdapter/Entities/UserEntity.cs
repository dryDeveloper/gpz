using Core.Models;

namespace SqlAdapter.Entities;

public class UserDto : Entity {
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Firstname { get; set; } = "";
    public string Lastname { get; set; } = "";
    public int UserProfileId { get; set; }
    public virtual UserProfile Profile { get; set; }
}
