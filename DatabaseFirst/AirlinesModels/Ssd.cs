using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Ssd
{
    public long SsdId { get; set; }

    public string SsdName { get; set; } = null!;

    public string SsdMemory { get; set; } = null!;

    public virtual Category SsdNavigation { get; set; } = null!;
}
