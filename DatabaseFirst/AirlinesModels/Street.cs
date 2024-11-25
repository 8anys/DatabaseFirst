using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Street
{
    public long StreetId { get; set; }

    public long CityId { get; set; }

    public string Street1 { get; set; } = null!;

    public virtual City City { get; set; } = null!;
}
