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
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _rewardService;

        public RewardController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

      //  [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var reward = await _rewardService.GetRewardAsync(id);
            return Ok(reward);
        }

      //  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllRewards()
        {
            var articles = await _rewardService.GeRewardsAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reward reward)
        {
            var createReward = await _rewardService.CreateRewardAsync(reward);


            return Ok(createReward);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Reward reward)
        {

            var dbArticle = await _rewardService.UpdateRewardAsync(reward);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _rewardService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}
