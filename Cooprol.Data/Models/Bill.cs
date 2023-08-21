namespace Cooprol.Data.Models;

public class Bill: BaseEntity<int>
{
    public string dateB {get; set;} = "";
    public int lProduced {get; set;}
    public int deductions {get; set;}
    public int toPay {get; set;}
}