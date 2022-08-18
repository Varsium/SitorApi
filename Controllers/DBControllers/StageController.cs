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
    public class StageController : ControllerBase
    {
        private readonly IStageService _stageService;

        public StageController(IStageService stageService)
        {
            _stageService = stageService;
        }

        //[AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var stage = await _stageService.GetStageAsync(id);
            return Ok(stage);
        }

       // [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllStages()
        {
            var articles =await _stageService.GetStagesAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Stage stage)
        {
            var createStage = await _stageService.CreateStageAsync(stage);


            return Ok(createStage);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Stage stage)
        {

            var dbArticle = await _stageService.UpdateStageAsync(stage);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess =  await _stageService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}

