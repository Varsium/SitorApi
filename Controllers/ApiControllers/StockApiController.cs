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
    [Route("api/[controller]")]
    [ApiController]
    public class StockApiController : ControllerBase
    {
        private readonly IStockApiService _stockApiService;

        public StockApiController(IStockApiService stockApiService)
        {
            _stockApiService = stockApiService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var shop = await _stockApiService.GetStockAsync(id);
            return Ok(shop);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllShops()
        {
            var shops = await _stockApiService.GetStocksAsync();
            return Ok(shops);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockApi stock)
        {
            var createShop = await _stockApiService.CreateStockAsync(stock);


            return Ok(createShop);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(StockApi stock)
        {

            var dbArticle = await _stockApiService.UpdateStockAsync(stock);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _stockApiService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}
