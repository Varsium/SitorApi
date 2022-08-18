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
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

      //  [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var equipment = await _equipmentService.GetEquipmentAsync(id);
            return Ok(equipment);
        }
      //  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEquipments()
        {
            var equipments = await _equipmentService.GetEquipmentsAsync();
            return Ok(equipments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            var createEquipment = await _equipmentService.CreateEquipmentAsync(equipment);


            return Ok(createEquipment);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Equipment equipment)
        {

            var dbArticle =await _equipmentService.UpdateEquipmentAsync(equipment);
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

