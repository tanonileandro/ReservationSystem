using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Client : User
    {
        public string Role { get; set; } = "client";
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
