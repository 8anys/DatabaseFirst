using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Job
{
    public long JobId { get; set; }

    public string JobName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
