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
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

       // [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var character =await _characterService.GetCharacterAsync(id);
            return Ok(character);
        }
     //   [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCharacters()
        {
            var articles =await _characterService.GetCharactersAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Character character)
        {
            var createCharacter = await _characterService.CreateCharacterAsync(character);


            return Ok(createCharacter);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Character character)
        {

            var dbArticle = await _characterService.UpdateCharacterAsync(character);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _characterService.DeleteAsync(id);
            return Ok(isSuccess);
        }

    }
}

