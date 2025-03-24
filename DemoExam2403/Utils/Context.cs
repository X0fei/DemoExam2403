using DemoExam2403.Context;
using DemoExam2403.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam2403.Utils
{
    public static class Context
    {
        public static User21Context DbContext { get; set; } = new();
        public static List<Product> products { get; set; } = [.. DbContext.Products
            .Include(product => product.TypeNavigation)
            .Include(product => product.PartnersProducts)];
        public static List<Partner> partners { get; set; } = [.. DbContext.Partners
            .Include(partner => partner.TypeNavigation)
            .Include(partner => partner.PartnersProducts)];
        public static List<ProductType> productTypes { get; set; } = [.. DbContext.ProductTypes];
    }
}
