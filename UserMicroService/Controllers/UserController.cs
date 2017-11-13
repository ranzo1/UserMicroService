using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UserMicroService.DataAccess;
using UserMicroService.Models;

namespace UserMicroService.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/User/{id}")]
        public User GetUserById(int id)
        {
            return UserDB.GetUserById(id);
        }

        [Route("api/User")]
        public List<User> GetAllUsers()
        {
            return UserDB.GetAllUsers();
        }
    }
}