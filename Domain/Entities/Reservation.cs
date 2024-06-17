using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string? ReservationName { get; set; }
        public int RoomId { get; set; }
        public int AdminId { get; set; }
        public int ClientId { get; set; }
        public bool State { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Client Client { get; set; }
        public Admin Admin { get; set; }

    }
}
