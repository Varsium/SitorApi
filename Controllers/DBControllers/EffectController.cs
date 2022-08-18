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
    public class EffectController : ControllerBase
    {
        private readonly IEffectService _effectService;

        public EffectController(IEffectService effectService)
        {
            _effectService = effectService;
        }

       // [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var effect = await _effectService.GetEffectAsync(id);
            return Ok(effect);
        }
      //  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEffects()
        {
            var effects = await _effectService.GetEffectsAsync(null);
            return Ok(effects);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Effect effect)
        {
            var createEffect = await _effectService.CreateEffectAsync(effect);


            return Ok(createEffect);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Effect effect)
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
