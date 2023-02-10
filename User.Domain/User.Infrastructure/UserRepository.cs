using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using User.Application;
using User.Domain;

namespace User.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }


        public Userd CreateUser(Userd user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }


        public List<Userd> GetAllUsers()
        {
            return _context.users.ToList();
        }

        public Userd? UpdateUser(Userd user, int id)
        {
            var u= _context.users.Find(id);
            if (u is null) return null;
            u.Name=user.Name;
            u.Email=user.Email;
            _context.SaveChanges();
            return u;
        }
        public List<Userd>? DeleteUser(int id) {
            var u = _context.users.Find(id);
            if(u is null) return null;
            _context.users.Remove(u);
            _context.SaveChanges();
            return _context.users.ToList();
        }
    }
}
