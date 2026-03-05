using BLL.Services.Interfaces;
using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Classes
{
   public class ItemService :GenericService<ItemRequest, ItemResponse, Item>, IItemService
    {
        private readonly IFileService _fileService;
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository repository,IFileService fileService, IItemRepository IItemRepository) :base (repository)
        {
            _fileService=fileService;
            _itemRepository=IItemRepository;
        }
        public async Task<int> CreateFile(ItemRequest itemRequest)
        {
            var entity = itemRequest.Adapt<Item>();
             entity.CreatedAt = DateTime.UtcNow;
            if (itemRequest.MainImage != null)
            {
                var image= await _fileService.UploadFileAsync(itemRequest.MainImage);
                entity.MainImage =  image;
            }
            else
            {
               
                Console.WriteLine("image is null");
            }
                return _itemRepository.Add(entity);
        }
    }
}
