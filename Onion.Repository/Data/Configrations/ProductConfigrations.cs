using Microsoft.EntityFrameworkCore;
using Onion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Repository.Data.Configrations
{
    public class ProductConfigrations:IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder) {
            builder.HasOne(p => p.ProductBrand).WithMany();
            builder.HasOne(p => p.ProductType).WithMany();


        }

    }
}
