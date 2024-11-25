using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Store
{
    public long StoreId { get; set; }

    public string StoreFullName { get; set; } = null!;

    public long EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
