namespace Cooprol.Data.Models;

public class Producer: BaseEntity<int>
{
    public string? name {get; set;}
    public string? numberCc {get; set;}
    public string? cellNumber {get; set;}
    public bool isActive {get; set;}
}
