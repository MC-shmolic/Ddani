using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DBL;

namespace SmthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CharactersDBController : ControllerBase
    {
                [HttpPost]
        [ActionName("GetCharacters")]
        public async Task<List<Characters>> GetCharacters()
        {
            CharactersDB CharactersDB = new CharactersDB();
            List<Characters> characters = await CharactersDB.GetAllAsync();
            return characters;
        }

        [HttpPost]
        [ActionName("InsertCharacter")]
        public async Task<int> InsertCharacter([FromBody] Characters c)
        {
            CharactersDB CharactersDB = new CharactersDB();
            int num = await CharactersDB.InsertAsync(c);
            return num;
        }

        [HttpPost]
        [ActionName("UpdateCharacter")]
        public async Task<int> UpdateCharacter([FromBody] Characters c)
        {
            CharactersDB CharactersDB = new CharactersDB();
            int num = await CharactersDB.UpdateAsync(c);
            return num;
        }

        [HttpPost]
        [ActionName("DeleteCharacter")]
        public async Task<int> DeleteCharacter([FromBody] int id)
        {
            CharactersDB CharactersDB = new CharactersDB();
            int num = await CharactersDB.DeleteAsync(id);
            return num;
        }
    }
}
