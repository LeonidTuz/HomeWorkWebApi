using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewHomeWorkWebApi.Data.Models.Users
{
    public class UserStorage : IUserStorage
    {
        public static List<User> userStorage = new List<User>();

        private int NextUserId => userStorage.Count() == 0 ? 1 : userStorage.Max(x => x.Id) + 1;

        public string UserGet(int id)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            foreach (var user in userStorage)
            {
                if (user.Id == id)
                {
                    var jsonUser = JsonSerializer.Serialize(user, options);
                    return jsonUser;
                };
            }

            return "Not Found";
        }



        public StringBuilder Render()
        {

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            StringBuilder userList = new StringBuilder();

            var delimeter = "\n";

            foreach (var user in userStorage)
            {
                string userJson = JsonSerializer.Serialize(user, options);
                userList.Append(userJson);
                userList.Append(delimeter);


            }

            return userList;
        }


        public void Add(User user)
        {
            user.Id = NextUserId;
            userStorage.Add(user);
        }

        public void Remove(int id)
        {
            foreach (var user in userStorage)
            {
                if (user.Id == id)
                {
                    userStorage.Remove(user);
                }
            }
        }
    }
}
