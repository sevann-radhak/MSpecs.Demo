using System;
using System.Collections.Generic;
using System.Text;

namespace SqlliteDemo
{
    public class CountryProvider : ICountryProvider
    {
        private readonly DataBaseContext _context;

        public CountryProvider(DataBaseContext context)
        {
            _context = context;
        }

        public Country Get(int id)
        {
            return _context.Countries.Find(id);
        }
    }
}
