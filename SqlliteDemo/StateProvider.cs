using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlliteDemo
{
    public class StateProvider : IStateProvider
    {
        private readonly DataBaseContext _context;

        public StateProvider(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<State>> GetStatesByCountryIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"The id must be a positive integer");
            }
            else
            {
                Country country = await _context.Countries.FindAsync(id);
                if (country == null)
                {
                    throw new Exception($"The Country {id} doesn't exist.");
                }
                else
                {
                    return await _context.States.Where(c => c.CountryId == id).ToListAsync();
                }
            }
        }
    }
}
