using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Controllers.ApiControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        private IItemApiService _itemService;

        public ItemApiController(IItemApiService itemService)
        {
            _itemService = itemService;
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
            public async Task<IActionResult> Create(ItemApi item)
            {
                var createItem = await _itemService.CreateItem(item);


                return Ok(createItem);
            }

            [Route("{id}")]
            [HttpPut]
            public async Task<IActionResult> Update(ItemApi item)
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