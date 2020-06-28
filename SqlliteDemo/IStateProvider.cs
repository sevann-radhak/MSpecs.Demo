using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlliteDemo
{
    public interface IStateProvider
    {
        Task<List<State>> GetStatesByCountryIdAsync(int id);
    }
}
