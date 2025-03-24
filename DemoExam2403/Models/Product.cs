using System;
using System.Collections.Generic;

namespace DemoExam2403.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? Type { get; set; }

    public string Name { get; set; } = null!;

    public string? Article { get; set; }

    public decimal? MinimalCost { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    public virtual ProductType? TypeNavigation { get; set; }
}
