using System;

namespace MSpecs.Demo
{
    public interface IUserProvider
    {
        User Get(int id);
    }
}
