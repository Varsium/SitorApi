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
    public class BackgroundController : ControllerBase
    {
        private readonly IBackgroundService _backgroundService;

        public BackgroundController(IBackgroundService backgroundService)
        {
            _backgroundService = backgroundService;
        }
      //  [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {
            var background =await _backgroundService.GetBackgroundAsync(id);
            return Ok(background);
        }
     //   [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllBackgrounds()
        {
            var articles = await _backgroundService.GetBackgroundsAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Background background)
        {
            var createBackground = await _backgroundService.CreateBackground(background);


            return Ok(createBackground);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Background background)
        {

            var dbBackground = await _backgroundService.UpdateBackgroundAsync(background);
            return Ok(dbBackground);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess =await _backgroundService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}
