﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : User
    {
        public Admin()
        {
            Role = "admin";
        }

        public string Role { get; private set; }
    }
}
