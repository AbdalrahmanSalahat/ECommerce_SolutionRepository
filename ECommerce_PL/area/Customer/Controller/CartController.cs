using BLL.Services.Interfaces;
using DAL.DTO.DTORequsts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce_PL.area.Customer.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]

    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [HttpPost("Cart")]
        public async Task<IActionResult> AddtoCart(CartRequest cartRequest, int userid)
        {


            return Ok(cartService.AddtoCart(cartRequest, userid));

        }

        /*        [HttpGet("GetCart")]*/
        /*   public async Task<IActionResult> GetCart()
           {

               var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
               var result= cartService.CartSummaryResponse(userID);
               return Ok(result);


           }*/

    }
}
