using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Controllers.ApiControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeApiController : ControllerBase
    {
        private readonly ITypeApiService _typeService;

            public TypeApiController(ITypeApiService typeService)
            {
                _typeService = typeService;
            }

            [AllowAnonymous]
            [Route("{id}")]
            [HttpGet]
            public async Task<IActionResult> Get(int id)
            {
                var type = await _typeService.GetTypeAsync(id);
                return Ok(type);
            }
            [AllowAnonymous]
            [HttpGet]
            public async Task<IActionResult> GetTypes()
            {
                var types = await _typeService.GetTypesAsync();
                return Ok(types);
            }

            [HttpPost]
            public async Task<IActionResult> Create(TypeApi type)
            {
                var createType = await _typeService.CreateTypeAsync(type);


                return Ok(createType);
            }

            [Route("{id}")]
            [HttpPut]
            public async Task<IActionResult> Update(TypeApi type)
            {

                var dbArticle = await _typeService.UpdateTypeAsync(type);
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