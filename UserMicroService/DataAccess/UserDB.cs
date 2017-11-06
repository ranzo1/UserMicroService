using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMicroService.Models;
using UserMicroService.Util;

namespace UserMicroService.DataAccess
{
    public static class UserDB
    {

        public static List<User> usersInMemory = new List<User>();

        public static List<User> GetUsers(string userName,ActiveStatusEnum activeStatusEnum)
        {
            return usersInMemory;
        }


        public static User GetUserById(int id)
        {

            foreach (User user in usersInMemory)
            {
                if (user.Id == id)
                {

                    return user;
                }
            }
            return null;
        }


        public static User CreateUser(User user)
        {

            usersInMemory.Add(user);
            return GetUserById(user.Id);

        }
    }
}