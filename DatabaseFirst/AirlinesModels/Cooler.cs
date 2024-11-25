using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Cooler
{
    public long CoolerId { get; set; }

    public string CoolerName { get; set; } = null!;

    public virtual Category CoolerNavigation { get; set; } = null!;
}
