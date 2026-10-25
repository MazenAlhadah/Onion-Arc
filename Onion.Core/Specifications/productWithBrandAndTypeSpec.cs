using Onion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Specifications
{
    public class productWithBrandAndTypeSpec:BaseSpecifications<Product>
    {
        public productWithBrandAndTypeSpec():base()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
        public productWithBrandAndTypeSpec(int id):base(p=>p.Id == id)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }


    }
}
