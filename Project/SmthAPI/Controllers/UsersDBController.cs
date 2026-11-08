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
        [HttpGet]
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
            //UsersDB UsersDB = new UsersDB();
            //int num = await UsersDB.DeleteAsync(id);
            //return num;

            UsersDB UsersDB = new UsersDB();
            int num = await UsersDB.UpdateAsyncDead(id);
            return num;
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<List<int>> Login([FromBody] Users u)
        {
            UsersDB UsersDB = new UsersDB();
            List<Users> characters = await UsersDB.GetAllAsync();

            foreach (Users ch in characters)
            {
                if (u.UserName == ch.UserName && u.UserPassword == ch.UserPassword)
                {
                    if (ch.UserRole == "Admin")
                        return new List<int> { 2, ch.UserID };

                    return new List<int> { 1, ch.UserID };
                }
            }

            return new List<int> { 0, -1 };
        }


        [HttpPost]
        [ActionName("GetUser")]
        public async Task<Users> GetUser([FromBody] int id)
        {
            UsersDB UsersDB = new UsersDB();
            List<Users> characters = await UsersDB.GetAllAsync();

            foreach (Users ch in characters)
            {
                if (id == ch.UserID)
                {
                    Users user = new Users(ch.UserID , ch.UserName , ch.UserPassword , ch.UserEmail , ch.UserRole);
                    return user;
                }
            }

            return null;
        }


        //[HttpPost]
        //[ActionName("Role")]
        //public async Task<string> Role([FromBody] Users u)
        //{
        //    UsersDB UsersDB = new UsersDB();
        //    List<Users> characters = await UsersDB.GetAllAsync();
        //    foreach (Users ch in characters)
        //    {
        //        if (u.UserName == ch.UserName && u.UserPassword == ch.UserPassword)
        //        {
        //            return u.UserRole;
        //        }
        //    }

        //    return "";
        //}
    }
}

