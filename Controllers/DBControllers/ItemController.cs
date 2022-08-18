using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Controllers.DBControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IEffectlistService _effectlistService;
        private readonly IEffectService _effectService;
        private readonly ITypeService _typeService;


        public ItemController(IItemService itemService, ICategoryService categoryService, IEffectlistService effectlistService, IEffectService effectService, ITypeService typeService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _effectlistService = effectlistService;
            _effectService = effectService;
            _typeService = typeService;
        }
        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
           var itemApi = await _itemService.GetItemAsync(id);
        
            return Ok(itemApi);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {

            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            var createItem = await _itemService.CreateItem(item);


            return Ok(createItem);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Item item)
        {

            var dbArticle = await _itemService.UpdateItem(item);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _itemService.Delete(id);
            return Ok(isSuccess);
        }
    }
}
