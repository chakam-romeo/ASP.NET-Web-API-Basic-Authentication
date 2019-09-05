using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstWebApiDemo.Models;

namespace FirstWebApiDemo.Models
{
    public class UserBL
    {
        public List<Users> GetUser()
        {
            List<Users> userList = new List<Users>();
            userList.Add(new Users()
            {
                ID = 101,
                UserName = "MaleUser",
                Name = "romses",
                Password = "123456"
            });
            userList.Add(new Users()
            {
                ID = 101,
                UserName = "FemaleUser",
                Password = "abcdef",
                Name = "romses"
            });
            return userList;
        }
    }
}