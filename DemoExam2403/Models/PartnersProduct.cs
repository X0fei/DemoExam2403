using System;
using System.Collections.Generic;

namespace DemoExam2403.Models;

public partial class PartnersProduct
{
    public int Id { get; set; }

    public int? Product { get; set; }

    public int? Partner { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? SaleDate { get; set; }

    public virtual Partner? PartnerNavigation { get; set; }

    public virtual Product? ProductNavigation { get; set; }
}
