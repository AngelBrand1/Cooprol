namespace Cooprol.Data.Models; 

public class Role: BaseEntity<int>
{
    public string Desciption {get; set;}
    public ICollection<User> Users {get; set;} = new HashSet<User>();
    public ICollection<UserRole> UserRole {get; set;}

}