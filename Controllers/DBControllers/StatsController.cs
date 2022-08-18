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
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

       // [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var stats = await _statsService.GetStatsAsync(id);
            return Ok(stats);
        }
      //  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetStatsSet()
        {
            var articles = await _statsService.GetStatsSetAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Stats stats)
        {
            var createStats = await _statsService.CreateStatsAsync(stats);


            return Ok(createStats);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Stats stats)
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