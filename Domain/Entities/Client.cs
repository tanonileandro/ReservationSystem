using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Client : User
    {
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
