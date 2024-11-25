using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Motherboard
{
    public long MotherboardId { get; set; }

    public string MotherboardName { get; set; } = null!;

    public virtual Category MotherboardNavigation { get; set; } = null!;
}
