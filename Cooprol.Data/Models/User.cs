using System.Data.Common;

namespace Cooprol.Data.Models;

public class User: BaseEntity<int>
{
    public string name {get; set;}
    public string NumberCc {get; set;}
    public string Email {get; set;}
    public string Username {get; set;}
    public string Password {get; set;}
}