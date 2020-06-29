using System.Collections.Generic;

namespace MSpecs.Demo
{
    public interface IUserManager
    {
        ICollection<User> Get();
        User Get(int id);
    }
}
