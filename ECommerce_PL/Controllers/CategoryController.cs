using Azure.Core;
using BLL.Services.Interfaces;
using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPost("create")]
        public IActionResult CreateCategory([FromBody] CategoryRequest Request)
        {
            return Ok(_Service.Add(Request));
        }
        [HttpGet("All")]

        public IActionResult GetAll()
        {
            return Ok(_Service.GetAll());
        }
        [HttpPost("delete/{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_Service.Remove(id));
        }
        [HttpPatch("Update/{id}")]

        public IActionResult Update([FromRoute]int id,[FromBody] CategoryRequest request)
        {
            return Ok(_Service.Update(id, request));
        }

    }
}
