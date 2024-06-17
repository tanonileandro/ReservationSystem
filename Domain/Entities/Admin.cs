using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Admin : User
    {
        public string Role {  get; set; } = "admin";
    }
}
