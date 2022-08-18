using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Controllers.ApiControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StageApiController : ControllerBase
    {
        private readonly IStageApiService _stageService;

        public StageApiController(IStageApiService stageService)
        {
            _stageService = stageService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var stage = await _stageService.GetStageAsync(id);
            return Ok(stage);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllStages()
        {
            var articles = await _stageService.GetStagesAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StageApi stage)
        {
            var createStage = await _stageService.CreateStageAsync(stage);


            return Ok(createStage);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(StageApi stage)
        {

            var dbArticle = await _stageService.UpdateStageAsync(stage);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _stageService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}
