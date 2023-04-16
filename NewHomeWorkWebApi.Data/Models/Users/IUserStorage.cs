using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHomeWorkWebApi.Data.Models.Users
{
    public interface IUserStorage
    {
        public void Add(User user);
        public void Remove(int id);
        public string UserGet(int id);
        public StringBuilder Render();
    }
}
