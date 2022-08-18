using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeItemApiController : ControllerBase
    {
        private readonly ITypeItemApiService _typeItemApiService;

        public TypeItemApiController(ITypeItemApiService typeItemApiService)
        {
            _typeItemApiService = typeItemApiService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var type = await _typeItemApiService.GetTypeItemAsync(id);
            return Ok(type);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            var types = await _typeItemApiService.GetTypeItemsAsync();
            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeItemApi type)
        {
            var createType = await _typeItemApiService.CreateTypeItemAsync(type);


            return Ok(createType);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(TypeItemApi type)
        {

            var dbArticle = await _typeItemApiService.UpdateTypeItemAsync(type);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _typeItemApiService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}