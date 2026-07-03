using FlipFlash.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Services
{
    public interface IFlashCardService
    {
        Task<IEnumerable<FlashCard>> GetAsync();
        Task<FlashCard?> GetByIdAsync(string id);
        Task SaveAsync(FlashCard card);
        Task DeleteAsync(FlashCard card);
        Task DeleteAllAsync();
        Task<IEnumerable<FlashCard>> GetByLocationAsync(string collectionId);
        Task<IEnumerable<FlashCard>> GetExpiredAsync();
        Task<IEnumerable<FlashCard>> GetExpiresTodayAsync();
        Task<IEnumerable<FlashCard>> GetExpiresSoonAsync(int days = 5);
    }
}
