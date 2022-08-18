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
    public class InventoryApiController : ControllerBase
    {
        private readonly IInventoryApiService _inventoryApiService;

        public InventoryApiController(IInventoryApiService inventoryApiService)
        {
            _inventoryApiService = inventoryApiService;
        }


        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var equipment = await _inventoryApiService.GetInventoryAsync(id);
            return Ok(equipment);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEquipments()
        {
            var equipments = await _inventoryApiService.GetInventoriesAsync();
            return Ok(equipments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventoryApi inventory)
        {
            var createEquipment = await _inventoryApiService.CreateInventoryAsync(inventory);


            return Ok(createEquipment);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(InventoryApi inventory)
        {

            var dbinventory = await _inventoryApiService.UpdateInventoryAsync(inventory);
            return Ok(dbinventory);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _inventoryApiService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}