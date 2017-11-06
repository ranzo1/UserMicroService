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

        public static List<User> GetUsers()   
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

        public static User GetUserByName(string userName)
        {

            foreach (User user in usersInMemory)
            {
                if (user.UserName ==userName)
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

        public static User UpdateUser(User updateUser)
        {

            foreach (User userInList in usersInMemory)
            {
                if (userInList.Id == updateUser.Id)
                {
                    userInList.UserName = updateUser.UserName;
                    userInList.Address = updateUser.Address;
                    userInList.Active = updateUser.Active;
                    userInList.Phone = updateUser.Phone;
                    userInList.Email = updateUser.Email;
                    userInList.CityName = updateUser.CityName;
                    userInList.CountryName = updateUser.CountryName;
                    userInList.ZipCode = updateUser.ZipCode;

                    return updateUser;

                }
            }
            return null;


        }

        public static void DeleteUser(User deleteUser)
        {
            usersInMemory.Remove(deleteUser);
        }
    }
}