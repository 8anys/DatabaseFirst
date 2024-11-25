using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Employee
{
    public long EmployeeId { get; set; }

    public long PersonId { get; set; }

    public long JobId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
