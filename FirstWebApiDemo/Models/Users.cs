﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApiDemo.Models
{
  
    public class Users
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}