using System;

namespace SqlliteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataBaseContext = new DataBaseContext("Server=(localdb)\\mssqllocaldb;Database=WebApiJwtDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            var countryProvider = new CountryProvider(dataBaseContext);
            var country = countryProvider.Get(7);

            Console.WriteLine($"Country: {country.Name} - {country.Description}");
        }
    }
}
