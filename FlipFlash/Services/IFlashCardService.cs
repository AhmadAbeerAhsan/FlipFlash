using FlipFlash.FlashCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Services
{
    public interface IFlashCardService
    {
        Task<IEnumerable<FlashCard.FlashCard>> GetAsync();
        Task<FlashCard.FlashCard?> GetByIdAsync(string id);
        Task SaveAsync(FlashCard.FlashCard card);
        Task DeleteAsync(FlashCard.FlashCard card);
        Task DeleteAllAsync();
        Task<IEnumerable<FlashCard.FlashCard>> GetByLocationAsync(string collectionId);
        Task<IEnumerable<FlashCard.FlashCard>> GetExpiredAsync();
        Task<IEnumerable<FlashCard.FlashCard>> GetExpiresTodayAsync();
        Task<IEnumerable<FlashCard.FlashCard>> GetExpiresSoonAsync(int days = 5);
    }
}
