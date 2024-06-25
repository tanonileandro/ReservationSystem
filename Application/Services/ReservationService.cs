using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HotelDbContext _context;

        public ReservationService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        Task<IEnumerable<Reservation>> IReservationService.GetAllReservationsAsync()
        {
            throw new NotImplementedException();
        }

        Task<Reservation> IReservationService.GetReservationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReservationAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
