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
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

       // [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var type = await _typeService.GetTypeAsync(id);
            return Ok(type);
        }
      //  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            var types =await _typeService.GetTypesAsync();
            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Type type)
        {
            var createType = await _typeService.CreateTypeAsync(type);


            return Ok(createType);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Type type)
        {

            var dbArticle =await _typeService.UpdateTypeAsync(type);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _typeService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}
