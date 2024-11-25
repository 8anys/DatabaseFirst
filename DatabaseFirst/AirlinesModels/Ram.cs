using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Ram
{
    public long RamId { get; set; }

    public string RamName { get; set; } = null!;

    public virtual Category RamNavigation { get; set; } = null!;
}
