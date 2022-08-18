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
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

            public StockController(IStockService stockService)
            {
                _stockService = stockService;
            }

          //  [AllowAnonymous]
            [Route("{id}")]
            [HttpGet]
            public async Task<IActionResult> Get(int id)
            {
                var stock = await _stockService.GetStockAsync(id);
                return Ok(stock);
            }

        //    [AllowAnonymous]
            [HttpGet]
            public async Task<IActionResult> GetAllStocks()
            {
                var stocks = await _stockService.GetStocksAsync();
                return Ok(stocks);
            }

            [HttpPost]
            public async Task<IActionResult> Create(Stock stock)
            {
                var createStock = await _stockService.CreateStockAsync(stock);


                return Ok(createStock);
            }

            [Route("{id}")]
            [HttpPut]
            public async Task<IActionResult> Update(Stock stock)
            {

                var dbArticle = await _stockService.UpdateStockAsync(stock);
                return Ok(dbArticle);
            }


            [Route("{id}")]
            [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                var isSuccess = await _stockService.DeleteAsync(id);
                return Ok(isSuccess);
            }
        }
    }