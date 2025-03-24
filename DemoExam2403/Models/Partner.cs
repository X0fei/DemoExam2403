using System;
using System.Collections.Generic;

namespace DemoExam2403.Models;

public partial class Partner
{
    public int Id { get; set; }

    public int? Type { get; set; }

    public string Name { get; set; } = null!;

    public string? Director { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Adress { get; set; }

    public string? Tin { get; set; }

    public int? Rating { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    public virtual PartnerType? TypeNavigation { get; set; }
}
