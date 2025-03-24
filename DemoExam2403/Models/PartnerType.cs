using System;
using System.Collections.Generic;

namespace DemoExam2403.Models;

public partial class PartnerType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
