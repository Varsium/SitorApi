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
    public class EquipmentItemsApiController : ControllerBase
    {

        private readonly IEquipmentItemsApiService _equipmentItemItemService;

        public EquipmentItemsApiController(IEquipmentItemsApiService equipmentItemItemService)
        {
            _equipmentItemItemService = equipmentItemItemService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var equipmentItem = await _equipmentItemItemService.GetEquipmentItemsAsync(id);
            return Ok(equipmentItem);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEquipments()
        {
            var equipmentItems = await _equipmentItemItemService.GetEquipmentItemssAsync();
            return Ok(equipmentItems);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentItemsApi equipmentItem)
        {
            var createEquipment = await _equipmentItemItemService.CreateEquipmentItemsAsync(equipmentItem);


            return Ok(createEquipment);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(EquipmentItemsApi equipmentItem)
        {

            var dbArticle = await _equipmentItemItemService.UpdateEquipmentItemsAsync(equipmentItem);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _equipmentItemItemService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}

