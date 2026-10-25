using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Api.DTOs;
using Onion.Core.Entities;
using Onion.Core.Repositories;
using Onion.Core.Specifications;

namespace Onion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : APIBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetProduct() {
            var Spec = new productWithBrandAndTypeSpec();
            var product = await _productRepo.GetAllWithSpecAsync(Spec);
            var MappedProducts=_mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDTO>>(product);
            return Ok(MappedProducts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var Spec = new productWithBrandAndTypeSpec(id);
            var product = await _productRepo.GetByIdWithSpecAsync(Spec);
            return Ok(product);

        }
    }
}
