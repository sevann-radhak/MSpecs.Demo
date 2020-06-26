using System;
using System.Collections.Generic;
using System.Text;

namespace MSpecs.Demo
{
    public class UserManager : IUserManager
    {
        private readonly IUserProvider _userProvider;

        public UserManager(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public User Get(int id)
        {
            if (id <= 0) throw new ArgumentException("User id should be a positive integer");

            var user = _userProvider.Get(id);

            return user == null
                ? throw new ApplicationException(
                    $"User with id {id} could not be found")
                : user;
        }
    }
}
