using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FlipFlash.Services
{
    public interface ICardCollectionService
    {

            Task<IEnumerable<CardCollection.CardCollection>> GetAsync();
            Task<CardCollection.CardCollection?> GetByIdAsync(string id);
            Task SaveAsync(CardCollection.CardCollection cardCollection);
            Task DeleteAsync(CardCollection.CardCollection cardCollection);
            Task DeleteAllAsync();
    }
}
