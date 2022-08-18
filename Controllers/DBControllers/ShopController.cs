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
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

    //    [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var shop =await _shopService.GetShopAsync(id);
            return Ok(shop);
        }

      //  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllShops()
        {
            var shops = await _shopService.GetShopsAsync();
            return Ok(shops);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shop shop)
        {
            var createShop = await _shopService.CreateShopAsync(shop);


            return Ok(createShop);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Shop shop)
        {

            var dbArticle = await _shopService.UpdateShopAsync(shop);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _shopService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}