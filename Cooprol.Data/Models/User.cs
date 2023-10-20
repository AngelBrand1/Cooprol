using System.Data.Common;

namespace Cooprol.Data.Models;

public class User: BaseEntity<int>
{
    public string Name {get; set;}
    public string NumberCc {get; set;}
    public string Email {get; set;}
    public string UserName {get; set;}
    public string Password {get; set;}

    public ICollection<Role> Roles {get; set;} = new HashSet<Role>();
    public ICollection<UserRole> UserRole {get; set;} = new HashSet<UserRole>();
}