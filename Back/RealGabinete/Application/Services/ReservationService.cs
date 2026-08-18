using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;
using System.Threading.Tasks;

namespace RealGabinete.Application.Services
{
    public class ReservationService
    {
        private readonly IUnitOfWork _uow;

        public ReservationService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _uow.Reservations.GetAllAsync();
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _uow.Reservations.GetByIdAsync(id);
        }

        public async Task<Reservation> AddAsync(Reservation reservation)
        {
            await _uow.Reservations.AddAsync(reservation);
            await _uow.SaveChangesAsync();
            return reservation;
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            await _uow.Reservations.UpdateAsync(reservation);
            await _uow.SaveChangesAsync();
        }
    }
}
