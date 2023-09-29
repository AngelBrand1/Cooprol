using System;
using System.Collections.Generic;

namespace Cooprol.Data.Models;

public  class BaseEntity<TId>
where TId: struct
{
    public TId Id {get;set;}
}
