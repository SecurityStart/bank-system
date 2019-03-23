﻿namespace BankSystem.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Card;

    public interface ICardService
    {
        Task<string> CreateAsync(CardCreateServiceModel model);

        Task<IEnumerable<T>> GetAllCardsAsync<T>(string userId)
            where T : CardBaseServiceModel;

        Task<bool> DeleteAsync(string id);

        Task<T> GetAsync<T>(
            string cardNumber,
            string cardExpiryDate,
            int cardSecurityCode,
            string cardOwner)
            where T : CardBaseServiceModel;
    }
}
