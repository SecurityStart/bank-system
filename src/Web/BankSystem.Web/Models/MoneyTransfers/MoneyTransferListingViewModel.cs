﻿namespace BankSystem.Web.Models.MoneyTransfers
{
    using System;
    using Common.AutoMapping.Interfaces;
    using Services.Models.MoneyTransfer;

    public class MoneyTransferListingViewModel : IMapWith<MoneyTransferListingServiceModel>
    {
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime MadeOn { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }
    }
}
