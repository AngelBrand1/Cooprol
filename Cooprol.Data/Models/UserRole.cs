namespace Cooprol.Data.Models;

public class UserRole: BaseEntity<int>
{
    public int IdUser {get; set;}
    public User user {get; set;}
    public int IdRole {get; set;}
    public Role Role {get; set;}
}