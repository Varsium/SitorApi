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
    public class EffectListApiController : ControllerBase
    {
        private readonly IEffectlistApiService _effectListService;

        public EffectListApiController(IEffectlistApiService effectService)
        {
            _effectListService = effectService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var effect = await _effectListService.GetEffectListAsync(id);
            return Ok(effect);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEffects()
        {
            var effects = await _effectListService.GetEffectListSetAsync();
            return Ok(effects);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EffectListApi effect)
        {
            var createEffect = await _effectListService.CreateEffectListAsync(effect);


            return Ok(createEffect);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(EffectListApi effect)
        {

            var dbArticle = await _effectListService.UpdateEffectListSetAsync(effect);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _effectListService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}

