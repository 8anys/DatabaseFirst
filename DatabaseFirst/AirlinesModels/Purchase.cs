using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Purchase
{
    public long PurchasesId { get; set; }

    public DateTime DataPurchase { get; set; }

    public long EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
