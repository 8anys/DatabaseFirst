using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Hdd
{
    public long HddId { get; set; }

    public string HddName { get; set; } = null!;

    public string HddMemory { get; set; } = null!;

    public virtual Category HddNavigation { get; set; } = null!;
}
