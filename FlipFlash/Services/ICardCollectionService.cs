using FlipFlash.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FlipFlash.Services
{
    public interface ICardCollectionService
    {
            Task<IEnumerable<CardCollection>> GetAsync();
            Task<CardCollection?> GetByIdAsync(string id);
            Task SaveAsync(CardCollection cardCollection);
            Task DeleteAsync(CardCollection cardCollection);
            Task DeleteAllAsync();
    }
}
