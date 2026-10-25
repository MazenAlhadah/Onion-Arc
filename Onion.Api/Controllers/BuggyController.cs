using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Api.Errors;
using Onion.Repository.Data;
using System.Security.Cryptography;

namespace Onion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : APIBaseController
    {
        private readonly OnionContext _db;

        public BuggyController(OnionContext db) { _db = db; }

        [HttpGet("NotFound")]
        public IActionResult GetNotFoundResult() {
            var Product = _db.Products.Find(10000);
            if (Product is null) return NotFound(new ApiResponse(404,"not found!!!!!"));
            return Ok(Product);
        }

        [HttpGet("ServerError")]
        public IActionResult GetServerError() {
            var Product = _db.Products.Find(100);
            var ProductToReturn = Product.ToString();
            return Ok(ProductToReturn);
        }


        [HttpGet("BadRequies")]
        public IActionResult GetBadRequiest(){
            return BadRequest();
        }





    }
}
