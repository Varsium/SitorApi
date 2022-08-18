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
    public class EffectApiController : ControllerBase
    {
        private readonly IEffectApiService _effectService;

            public EffectApiController(IEffectApiService effectService)
            {
                _effectService = effectService;
            }

            [AllowAnonymous]
            [Route("{id}")]
            [HttpGet]
            public async Task<IActionResult> Get(int id)
            {
                var effect = await _effectService.GetEffectAsync(id);
                return Ok(effect);
            }
            [AllowAnonymous]
            [HttpGet]
            public async Task<IActionResult> GetAllEffects()
            {
                var effects = await _effectService.GetEffectsAsync();
                return Ok(effects);
            }

            [HttpPost]
            public async Task<IActionResult> Create(EffectApi effect)
            {
                var createEffect = await _effectService.CreateEffectAsync(effect);


                return Ok(createEffect);
            }

            [Route("{id}")]
            [HttpPut]
            public async Task<IActionResult> Update(EffectApi effect)
            {

                var dbArticle = await _effectService.UpdateEffectAsync(effect);
                return Ok(dbArticle);
            }


            [Route("{id}")]
            [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                var isSuccess = await _effectService.DeleteAsync(id);
                return Ok(isSuccess);
            }
        }
    }