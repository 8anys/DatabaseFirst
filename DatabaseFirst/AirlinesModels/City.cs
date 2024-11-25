using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class City
{
    public long CityId { get; set; }

    public long DistrictId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual District District { get; set; } = null!;

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
}
