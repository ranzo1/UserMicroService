using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserMicroService.Models;
using UserMicroService.Util;
using System.Data;

namespace UserMicroService.DataAccess
{
    public static class UserDB
    {

        public static User ReadRowFromDB(SqlDataReader reader)
        {
            User userToReturn = new User();

            userToReturn.Id = (int)reader["Id"];
            userToReturn.Name = (string)reader["Name"];
            userToReturn.Address = (string)reader["Address"];
            userToReturn.Email = (string)reader["Email"];
            userToReturn.UserTypeId = (int)reader["UserTypeId"];

            return userToReturn;
        }


        public static User GetUserById(int id)
        {

            try
            {
                User user = new User();

                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                
                    SELECT
                    * FROM 
                        [user].[User]
                    WHERE 
                        [Id]=@Id ");
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = ReadRowFromDB(reader);
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public static List<User> GetAllUsers()
        {

            try
            {
                List<User>users = new List<User>();

                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                
                    SELECT
                    * FROM 
                        [user].[User]
                    ");

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       while (reader.Read())
                        {
                            users.Add(ReadRowFromDB(reader));
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       /* public static User CreateUser(User newUser)
        {

            try
            {
               // User user = new User();

                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                
                    INSERT INTO [user].[User](Name,Address,Email,UserTypeId)
                    values(@Name,@Address,@Email,@UserTypeId) "


                     );
                    //command.Parameters.Add("@Id", SqlDbType.Int);
                   // command.Parameters["@Id"].Value = id;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = ReadRowFromDB(reader);
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }*/


    }
}