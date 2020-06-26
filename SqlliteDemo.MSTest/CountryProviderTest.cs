using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

                Assert.Equals("Colombia", country.Name);
            }

        }
    }
}
