﻿namespace CentralApi.Infrastructure
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public static class ApplicationBuilderExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<CentralApiDbContext>();
                dbContext.Database.Migrate();

                // Seed data
                SeedAvailableBanks(dbContext);
            }
        }

        private static void SeedAvailableBanks(CentralApiDbContext dbContext)
        {
            if (!dbContext.Banks.Any())
            {
                dbContext.AddRange(
                    new Bank
                    {
                        Location = "Bulgaria",
                        Name = "Bank system",
                        ShortName = "BS",
                        SwiftCode = "ABC",
                        ApiKey = "<RSAKeyValue><Modulus>uBJGDt7UVg068eAXtaJ8wxbTLtxJWubChoTCCljt4t8eCcUQTjbVjmiX4n9q01PyfP3Xe2MqKx0HhSygSQr4GTsPhUo44EEJr9E6ZgAjQcBJTbRop4i06BFk+u0x0P/9nZtjQQqFhKrTdVPP9rSc8CYYDsEVzsQTtjKZdtUkPFITfz6fwJHQm2Zswqwu9sSlIIwknz0jKG7lnbEwxrqQy57jjxM7ZujYCop+N20KvBIHLquuH3wkTIxmj4nZLscYBbAE7J4JhuHVE/fCJFIA+M9JgKVvEHeC5HIqshMSaAGRv9Th6HHk0v4QFm3NdpZsVf2Qhu0iOap3fHHoAypFZQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>",
                        AppId = Guid.NewGuid().ToString(),
                        ApiAddress = "https://localhost:5010/api/receiveMoneyTransfer",

                    });
                dbContext.SaveChanges();
            }
        }
    }
}
