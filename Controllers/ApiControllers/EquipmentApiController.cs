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
    public class EquipmentApiController : ControllerBase
    {

        private readonly IEquipmentApiService _equipmentService;

        public EquipmentApiController(IEquipmentApiService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var equipment = await _equipmentService.GetEquipmentAsync(id);
            return Ok(equipment);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEquipments()
        {
            var equipments = await _equipmentService.GetEquipmentsAsync();
            return Ok(equipments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentApi equipment)
        {
            var createEquipment = await _equipmentService.CreateEquipmentAsync(equipment);


            return Ok(createEquipment);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(EquipmentApi equipment)
        {

            var dbArticle = await _equipmentService.UpdateEquipmentAsync(equipment);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _equipmentService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}