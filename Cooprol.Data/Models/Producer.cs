using System;
using System.Collections.Generic;

namespace Cooprol.Data.Models;

public  class Producer: BaseEntity<int>
{

    public string Name { get; set; } = null!;

    public string NumberCc { get; set; } = null!;

    public string CellNumber { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
