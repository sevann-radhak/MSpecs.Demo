using System.Collections.Generic;

namespace MSpecs.Demo
{
    public interface IUserProvider
    {
        ICollection<User> Get();
        User Get(int id);
    }
}
