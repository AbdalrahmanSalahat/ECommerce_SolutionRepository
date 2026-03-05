using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_PL.area.Customer.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CategoryController : ControllerBase
    {
        public CategoryController(ICategoryService Service)
        {
            _Service = Service;
        }
        private readonly ICategoryService _Service;
        [HttpGet("{id}")]

        public IActionResult GetCategory([FromRoute] int id)
        {
            return Ok(_Service.GetID(id));
        }

        [HttpGet("All")]

        public IActionResult GetAll()
        {
            return Ok(_Service.GetAll());
        }
    }
}
