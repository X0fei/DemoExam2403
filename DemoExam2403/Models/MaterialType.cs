using System;
using System.Collections.Generic;

namespace DemoExam2403.Models;

public partial class MaterialType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? ErrorPercentage { get; set; }
}
