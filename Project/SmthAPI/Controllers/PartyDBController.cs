using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DBL;

namespace SmthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartyDBController : ControllerBase
    {
        [HttpGet]
        [ActionName("GetParty")]
        public async Task<List<Party>> GetCharacters()
        {
            PartyDB PartyDB = new PartyDB();
            List<Party> characters = await PartyDB.GetAllAsync();
            return characters;
        }

        [HttpPost]
        [ActionName("InsertParty")]
        public async Task<int> InsertCharacter([FromBody] Party c)
        {
            PartyDB PartyDB = new PartyDB();
            int num = await PartyDB.InsertAsync(c);
            return num;
        }

        [HttpPost]
        [ActionName("UpdateParty")]
        public async Task<int> UpdateCharacter([FromBody] Party c)
        {
            PartyDB PartyDB = new PartyDB();
            int num = await PartyDB.UpdateAsync(c);
            return num;
        }

        [HttpPost]
        [ActionName("DeleteParty")]
        public async Task<int> DeleteCharacter([FromBody] int id)
        {
            //PartyDB PartyDB = new PartyDB();
            //int num = await PartyDB.DeleteAsync(id);
            //return num;

            PartyDB PartyDB = new PartyDB();
            int num = await PartyDB.UpdateAsyncDead(id);
            return num;
        }

        [HttpPost]
        [ActionName("GetPartybyID")]
        public async Task<Party> GetParty([FromBody] int id)
        {
            PartyDB PartyDB = new PartyDB();
            List<Party> characters = await PartyDB.GetAllAsync();

            foreach (Party ch in characters)
            {
                if (id == ch.PartyID)
                {
                    Party Party = new Party(ch.PartyID, ch.AdminID, ch.PartyName, ch.Available);
                    return Party;
                }
            }

            return null;
        }
    }
}
