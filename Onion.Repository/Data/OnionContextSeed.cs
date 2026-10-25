using Onion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onion.Repository.Data
{
    public class OnionContextSeed
    {
        public static async Task SeedAsync(OnionContext dbContext)
        {
            if (!dbContext.ProductBrands.Any()){
                var BrandsData = File.ReadAllText("../Onion.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                if (brands?.Count > 0) {
                    foreach (var brand in brands) {
                        await dbContext.Set<ProductBrand>().AddAsync(brand);
                    }
                    await dbContext.SaveChangesAsync();

                }
            }

            if (!dbContext.ProductTypes.Any())
            {

                var TypeData = File.ReadAllText("../Onion.Repository/Data/DataSeed/types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);
                if (Types?.Count > 0)
                {
                    foreach (var Type in Types)
                    {
                        await dbContext.Set<ProductType>().AddAsync(Type);
                    }
                    await dbContext.SaveChangesAsync();

                }
            }

            if (!dbContext.Products.Any())
            {

                var ProductsData = File.ReadAllText("../Onion.Repository/Data/DataSeed/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products?.Count > 0)
                {
                    foreach (var product in Products)
                    {
                        await dbContext.Set<Product>().AddAsync(product);
                    }
                    await dbContext.SaveChangesAsync();

                }
            }
            

        }
    }
}
