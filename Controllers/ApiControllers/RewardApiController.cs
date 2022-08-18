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
    public class RewardApiController : ControllerBase
    {


        private readonly IRewardApiService _rewardService;

        public RewardApiController(IRewardApiService rewardService)
        {
            _rewardService = rewardService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var reward = await _rewardService.GetRewardAsync(id);
            return Ok(reward);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllRewards()
        {
            var articles = await _rewardService.GeRewardsAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RewardApi reward)
        {
            var createReward = await _rewardService.CreateRewardAsync(reward);


            return Ok(createReward);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(RewardApi reward)
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