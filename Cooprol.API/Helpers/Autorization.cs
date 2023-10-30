namespace Cooprol.API.Helpers;

public class Autorization
{
    public enum Roles
    {
        Manager,
        Treasurer,
        Employee
    }

    public const Roles DefaultRole = Roles.Employee; 
}