using System;
using System.Collections.Generic;
using System.Linq;

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

    //Список партнёров товара
    public string PartnerNames
    {
        get
        {
            return string.Join(", ", PartnersProducts.Select(p => p.PartnerNavigation.Name));
        }
    }

    //В зависимости от количества проданой (за 2024 год) продуктции, товар окрашивается в определённый цвет
    public string ItemColor
    {
        get
        {
            DateOnly startDate = new DateOnly(2024, 01, 01);
            DateOnly endDate = new DateOnly(2025, 01, 01);
            switch (PartnersProducts.Where(p => p.SaleDate >= startDate && p.SaleDate < endDate).Select(p => p.Quantity).Sum())
            {
                case < 10000: return "Salmon";
                case < 60000: return "SandyBrown";
                case >= 60000: return "PaleGreen";
            }
            return "#F4E8D3";
        }
    }
}
