using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Processor
{
    public long ProcessorId { get; set; }

    public string ProcessorName { get; set; } = null!;

    public string ProcessprCore { get; set; } = null!;

    public virtual Category ProcessorNavigation { get; set; } = null!;
}
