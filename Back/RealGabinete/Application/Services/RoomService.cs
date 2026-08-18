using RealGabinete.Domain.Entities;
using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Application.Services
{
    public class RoomService
    {
        private readonly IUnitOfWork _uow;

        public RoomService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _uow.Rooms.GetAllAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _uow.Rooms.GetByIdAsync(id);
        }

        public async Task<Room> AddAsync(Room room)
        {
            await _uow.Rooms.AddAsync(room);
            await _uow.SaveChangesAsync();
            return room;
        }

        public async Task RemoveAsync(int id)
        {
            await _uow.Rooms.RemoveAsync(id);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            await _uow.Rooms.UpdateAsync(room);
            await _uow.SaveChangesAsync();
        }
    }
}
