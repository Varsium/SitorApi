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
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

      //  [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var player =await _playerService.GetPlayerAsync(id);
            return Ok(player);
        }

      //  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players =await _playerService.GetPlayersAsync();
            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            var createPlayer = await _playerService.CreatePlayerAsync(player);


            return Ok(createPlayer);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Player player)
        {

            var dbArticle =await _playerService.UpdatePlayerAsync(player);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _playerService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}
