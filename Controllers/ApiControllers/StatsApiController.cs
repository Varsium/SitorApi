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
    public class StatsApiController : ControllerBase
    {
        private readonly IStatsApiService _statsService;

        public StatsApiController(IStatsApiService statsService)
        {
            _statsService = statsService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var stats = await _statsService.GetStatsAsync(id);
            return Ok(stats);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetStatsSet()
        {
            var articles = await _statsService.GetStatsSetAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StatsApi stats)
        {
            var createStats = await _statsService.CreateStatsAsync(stats);


            return Ok(createStats);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(StatsApi stats)
        {

            var dbArticle = await _statsService.UpdateStatsAsync(stats);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _statsService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}