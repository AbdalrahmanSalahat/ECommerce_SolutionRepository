using BLL.Services.Classes;
using BLL.Services.Interfaces;
using DAL.DTO.DTORequsts;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce_PL.area.Admin.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService; 
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] ItemRequest itemRequest)
        {
           
            var item = await _itemService.CreateFile(itemRequest);
            return Ok(item);
        }




    }
}
