using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Controllers.ApiControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopApiController : ControllerBase
    {
        private readonly IShopApiService _shopService;

        public ShopApiController(IShopApiService shopService)
        {
            _shopService = shopService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var shop = await _shopService.GetShopAsync(id);
            return Ok(shop);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllShops()
        {
            var shops = await _shopService.GetShopsAsync();
            return Ok(shops);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopApi shop)
        {
            var createShop = await _shopService.CreateShopAsync(shop);


            return Ok(createShop);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(ShopApi shop)
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