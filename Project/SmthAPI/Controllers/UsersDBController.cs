using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DBL;

namespace SmthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersDBController : ControllerBase
    {
        [HttpPost]
        [ActionName("GetUsers")]
        public async Task<List<Users>> GetCharacters()
        {
            UsersDB UsersDB = new UsersDB();
            List<Users> characters = await UsersDB.GetAllAsync();
            return characters;
        }

        [HttpPost]
        [ActionName("InsertUser")]
        public async Task<int> InsertCharacter([FromBody] Users c)
        {
            UsersDB UsersDB = new UsersDB();
            int num = await UsersDB.InsertAsync(c);
            return num;
        }

        [HttpPost]
        [ActionName("UpdateUser")]
        public async Task<int> UpdateCharacter([FromBody] Users c)
        {
            UsersDB UsersDB = new UsersDB();
            int num = await UsersDB.UpdateAsync(c);
            return num;
        }

        [HttpPost]
        [ActionName("DeleteUser")]
        public async Task<int> DeleteCharacter([FromBody] int id)
        {
            UsersDB UsersDB = new UsersDB();
            int num = await UsersDB.DeleteAsync(id);
            return num;
        }
    }
}
