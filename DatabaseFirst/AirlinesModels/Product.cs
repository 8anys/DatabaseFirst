using System;
using System.Collections.Generic;

namespace DatabaseFirst.AirlinesModels;

public partial class Product
{
    public long ProductId { get; set; }

    public long CategoryId { get; set; }

    public string? ProductName { get; set; }

    public virtual Category Category { get; set; } = null!;
}
