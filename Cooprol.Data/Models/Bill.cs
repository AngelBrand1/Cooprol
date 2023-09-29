using System;
using System.Collections.Generic;

namespace Cooprol.Data.Models;

public class Bill : BaseEntity<int>
{

    public string DateB { get; set; } = null!;

    public int LProduced { get; set; }

    public int Deductions { get; set; }

    public int ToPay { get; set; }

    public int IdProducer { get; set; }

    public virtual Producer? IdProducerNavigation { get; set; }
}
