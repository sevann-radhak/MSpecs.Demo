using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlliteDemo.MSTest
{
    [TestClass]
    public class CountryProviderTest
    {
        [TestMethod]
        public void Test_Get_By_Id()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DataBaseContext>().UseSqlite(connection).Options;

            using (var context = new DataBaseContext(options))
            {
                context.Database.EnsureCreated();
            }

            using (var context = new DataBaseContext(options))
            {
                context.Countries.Add(new Country { Id = 1, Description = "First country", Name = "Colombia" });
                context.SaveChanges();
            }

            using (var context = new DataBaseContext(options))
            {
                var provider = new CountryProvider(context);
                var country = provider.Get(1);

                Assert.AreEqual("Colombia", country.Name);
            }
        }

        [TestMethod]
        public async Task Get_States_By_Country_Id()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DataBaseContext>().UseSqlite(connection).Options;

            using (var context = new DataBaseContext(options))
            {
                await context.Database.EnsureCreatedAsync();
            }

            using (var context = new DataBaseContext(options))
            {
                await context.Countries.AddAsync(new Country { Id = 1, Description = "First country", Name = "Colombia" });
                await context.Countries.AddAsync(new Country { Id = 2, Description = "Second country", Name = "Argentina" });
                await context.States.AddAsync(new State { Id = 1, Description = "First State", Name = "Antioquia", CountryId = 1 });
                await context.States.AddAsync(new State { Id = 2, Description = "Second State", Name = "Santander", CountryId = 1 });
                await context.States.AddAsync(new State { Id = 3, Description = "Third State", Name = "Buenos Aires", CountryId = 2 });
                await context.SaveChangesAsync();
            }

            using (var context = new DataBaseContext(options))
            {
                var provider = new StateProvider(context);
                var states1 = await provider.GetStatesByCountryIdAsync(1);
                var states2 = await provider.GetStatesByCountryIdAsync(2);

                try
                {
                    var exc = Assert.ThrowsException<ArgumentException>(() => provider.GetStatesByCountryIdAsync(3));
                }
                catch (Exception exce)
                {
                    Assert.IsTrue(exce.Message is "Assert.ThrowsException failed. No exception thrown. ArgumentException exception was expected. ");
                }
                try
                {
                    var exc = Assert.ThrowsException<ArgumentException>(() => provider.GetStatesByCountryIdAsync(0));
                }
                catch (Exception exce)
                {
                    Assert.IsTrue(exce.Message is "Assert.ThrowsException failed. No exception thrown. ArgumentException exception was expected. ");
                }

                Assert.AreEqual(2, states1.Count);
                Assert.AreEqual(1, states2.Count);
            }
        }
    }
}
