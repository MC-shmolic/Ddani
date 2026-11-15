using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DBL;

namespace SmthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartyUserUserDBController : ControllerBase
    {
        [HttpGet]
        [ActionName("GetPartyUser")]
        public async Task<List<PartyUser>> GetCharacters()
        {
            PartyUserDB PartyUserDB = new PartyUserDB();
            List<PartyUser> characters = await PartyUserDB.GetAllAsync();
            return characters;
        }

        [HttpPost]
        [ActionName("InsertPartyUser")]
        public async Task<int> InsertCharacter([FromBody] PartyUser c)
        {
            PartyUserDB PartyUserDB = new PartyUserDB();
            int num = await PartyUserDB.InsertAsync(c);
            return num;
        }

        [HttpPost]
        [ActionName("UpdatePartyUser")]
        public async Task<int> UpdateCharacter([FromBody] PartyUser c)
        {
            PartyUserDB PartyUserDB = new PartyUserDB();
            int num = await PartyUserDB.UpdateAsync(c);
            return num;
        }

        [HttpPost]
        [ActionName("DeletePartyUser")]
        public async Task<int> DeleteCharacter([FromBody] int id)
        {
            PartyUserDB PartyUserDB = new PartyUserDB();
            int num = await PartyUserDB.DeleteAsync(id);
            return num;
        }


    }
}
