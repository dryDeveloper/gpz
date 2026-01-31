using Core.Models;

namespace SqlRepositoryAdapter.Entities;

public class UserEntity(string usr, string pwd, string first, string last, int profileId) : Entity {

    public string Username { get; set; } = usr;
    public string Password { get; set; } = pwd;
    public string Firstname { get; set; } = first;
    public string Lastname { get; set; } = last;
    public int UserProfileId { get; set; } = profileId;
    public UserProfileEntity? UserProfile { get; set; } 

    public UserEntity() : this("", "", "", "", -1) {}

}
