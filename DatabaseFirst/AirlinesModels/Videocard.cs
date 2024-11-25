using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Videocard
{
    public long VideocardId { get; set; }

    public string VideocardSeries { get; set; } = null!;

    public string VideocardName { get; set; } = null!;

    public virtual Category VideocardNavigation { get; set; } = null!;
}
