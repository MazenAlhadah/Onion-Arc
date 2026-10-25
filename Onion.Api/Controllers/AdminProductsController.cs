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
    public class AdminProductsController : APIBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;


        public AdminProductsController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product p)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Add(p);
            }
            return Ok(p);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var spec = new productWithBrandAndTypeSpec(id);
            var product = await _productRepo.GetByIdWithSpecAsync(spec);
            if (product == null)
                return NotFound();
            var mappedProduct = _mapper.Map<Product, ProductToReturnDTO>(product);
            return Ok(mappedProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductToReturnDTO productDto)
        {
            var spec = new productWithBrandAndTypeSpec(id);
            var product = await _productRepo.GetByIdWithSpecAsync(spec);
            if (product == null) return NotFound();

            _mapper.Map(productDto, product);
            _productRepo.Update(product);

            return Ok(_mapper.Map<ProductToReturnDTO>(product));
        }
    }
}