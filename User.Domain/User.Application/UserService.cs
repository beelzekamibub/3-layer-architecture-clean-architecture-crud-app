using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;

namespace User.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Userd CreateUser(Userd movie)
        {
            _userRepository.CreateUser(movie);
            return movie;
        }

        public List<Userd> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users;
        }

        public Userd? UpdateUser(Userd user, int id)
        {
            var u = _userRepository.UpdateUser(user,id);
            if (u is null) return null;
            return u;
        }

        public List<Userd>? DeleteUser(int id) { 
            var u =_userRepository.DeleteUser(id);
            if (u is null) return null;
            return u;
        }
    }
}
