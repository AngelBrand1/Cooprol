using System.ComponentModel.DataAnnotations;

namespace Cooprol.API.Dtos;

public class RegisterDto
{
    [Required]
     public string Name {get; set;}
    [Required]
    public string NumberCc {get; set;}
    [Required]
    public string Email {get; set;}
    [Required]
    public string UserName {get; set;}
    [Required]
    public string Password {get; set;}
}