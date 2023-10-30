using System.ComponentModel;
using Cooprol.Data.Models;
namespace Cooprol.API.Dtos;

public class DataUserDto 
{
    public string Message {get; set;}
    public bool isAutenticate {get;set;}
    public string Email {get; set;}
    public string UserName {get; set;}
    public List<string> Roles {get;set;}
    public string Token {get;set;}
}