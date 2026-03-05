using Azure;
using BLL.Services.Interfaces;
using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Classes
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public int AddtoCart(CartRequest CartRequest, int UserId)
        {

            var newitem = new cart { ProductId = CartRequest.ProductID, UserId = UserId, Count = 1 };
            return _cartRepository.Add(newitem);

        }

        /* public CartSummaryResponse CartSummaryResponse(string UserId)
         {
             var cartlist = _cartRepository.GetCartByUserId(UserId);
             var select = new CartSummaryResponse
             {
                 Cartlist = cartlist.Select(c => new CartResponse
                 {
                     ProductName = c.Product.Name,

                     Count = c.Count,
                     ProductId = c.ProductId,
                     Price= c.Product.Price


                 }).ToList()
             };
             return select;
         }
     */
    }
}
