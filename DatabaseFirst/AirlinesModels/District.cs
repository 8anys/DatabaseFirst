using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class District
{
    public long DistrictId { get; set; }

    public string? DistrictName { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
