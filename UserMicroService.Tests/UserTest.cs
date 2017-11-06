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

        
        private User CreateTestUser()
        {
            User user = new User
            {

                Id = 1,
                UserName = "ranzo1",
                Email = "protic80@gmail.com",
                Address = "Safarikova 20",
                ZipCode = "22211",
                CityName = "Novi sad",
                CountryName = "Srbija",
                Phone = "0640164519",
                Active = false

            };

            return user;
        }

        [Test]
        public void Get_All_Users_Success()
        {

            User user = CreateTestUser();

            User user2 = CreateTestUser();


            ClearUserList();

            UserDB.CreateUser(user);
            UserDB.CreateUser(user2);

            Assert.AreEqual(2, UserDB.GetUsers().Count);
        }

        [Test]
        public void Get_UserByName_Success()
        {

            User user = CreateTestUser();

            ClearUserList();

            UserDB.CreateUser(user);
         
            Assert.AreEqual(user, UserDB.GetUserByName(user.UserName));
        }

        [Test]
        public void Get_UserById_Success()
        {
            User user = CreateTestUser();

            ClearUserList();

            UserDB.CreateUser(user);

            Assert.AreEqual(user, UserDB.GetUserById(user.Id));
        }

        [Test]
        public void Create_User_Success()
        {
            User user = CreateTestUser();

            ClearUserList();

            UserDB.CreateUser(user);

            Assert.AreEqual(1, UserDB.GetUsers().Count);
        }

        [Test]
        public void Delete_User_Success()
        {
            User user = CreateTestUser();

            ClearUserList();

            UserDB.CreateUser(user);

            UserDB.DeleteUser(user);

            Assert.AreEqual(0, UserDB.GetUsers().Count);
        }

        [Test]
        public void Update_User_Success()
        {

            User user = CreateTestUser();
            user.Address = "Veliki Radinci";

            ClearUserList();

            UserDB.CreateUser(CreateTestUser());
            UserDB.UpdateUser(user);

            Assert.AreEqual("Veliki Radinci", UserDB.GetUserById(user.Id).Address);




        }

        
       
    }
}
