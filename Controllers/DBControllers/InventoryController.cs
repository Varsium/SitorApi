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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

      //  [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var inventory =await _inventoryService.GetInventoryAsync(id);
            return Ok(inventory);
        }
      //  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllInventories()
        {
            var inventories = await _inventoryService.GetInventoriesAsync();
            return Ok(inventories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            var createInventory = await _inventoryService.CreateInventoryAsync(inventory);


            return Ok(createInventory);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Inventory inventory)
        {

            var dbArticle = await _inventoryService.UpdateInventoryAsync(inventory);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _inventoryService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}

