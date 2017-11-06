using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroService.DataAccess;
using UserMicroService.Models;

namespace UserMicroService.Tests
{
    public class UserTest
    {
        public void ClearUserList()
        {
            UserDB.usersInMemory.Clear();
        }

        [Test]
        public void Get_All_Users_Success()
        {

            User user = new User
            {

                Id = 1,
                UserName = "ranzo1",

                


            };
        }
       
    }
}
