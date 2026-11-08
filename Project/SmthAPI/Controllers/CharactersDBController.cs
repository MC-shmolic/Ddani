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
        [HttpGet]
        [ActionName("GetCharacters")]
        public async Task<List<Characters>> GetCharacters()
        {
            CharactersDB CharactersDB = new CharactersDB();
            List<Characters> characters = await CharactersDB.GetAllAsync();
            return characters;
        }

        [HttpPost]
        [ActionName("GetCharactersUser")]
        public async Task<List<Characters>> GetCharactersUser([FromBody] int UserID)
        {
            CharactersDB CharactersDB = new CharactersDB();

            List<Characters> characters = await CharactersDB.GetAllAsync();

            List<Characters> charcters = new List<Characters>();

            foreach (Characters c in characters)
            {
                if (c.UserID == UserID)
                {
                    charcters.Add(c);
                }
            }

            return charcters;
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
