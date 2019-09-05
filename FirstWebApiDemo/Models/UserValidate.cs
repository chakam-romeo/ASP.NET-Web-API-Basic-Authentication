using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApiDemo.Models
{
    public class UserValidate
    {
        public static bool Login(String username, string password)
        {
            UserBL userBL = new UserBL();
            var UserList = userBL.GetUser();

            return UserList.Any(user=>user.UserName.Equals(username,StringComparison.OrdinalIgnoreCase) && user.Password==password);
        }
    }
}