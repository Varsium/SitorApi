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
    public class InventoryItemsApiController : ControllerBase
    {
        private readonly IInventoryItemsApiService _inventoryItemsItemsApiService;

        public InventoryItemsApiController(IInventoryItemsApiService inventoryItemsApiService)
        {
            _inventoryItemsItemsApiService = inventoryItemsApiService;
        }


        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var equipment = await _inventoryItemsItemsApiService.GetInventoryItemsAsync(id);
            return Ok(equipment);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEquipments()
        {
            var equipments = await _inventoryItemsItemsApiService.GetInventoriesItemsAsync();
            return Ok(equipments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventoryItemsApi inventory)
        {
            var createEquipment = await _inventoryItemsItemsApiService.CreateInventoryItemstAsync(inventory);


            return Ok(createEquipment);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(InventoryItemsApi inventory)
        {

            var dbinventory = await _inventoryItemsItemsApiService.UpdateInventoryItemsAsync(inventory);
            return Ok(dbinventory);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _inventoryItemsItemsApiService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}