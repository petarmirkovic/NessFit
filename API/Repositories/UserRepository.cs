using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.Users.Where(u=>u.UserId==id).FirstOrDefault();
        }

        public User GetByUsername(string username)
        {
            return _context.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return _context.Users.Any(u => u.UserId == id);
        }

        public bool Exists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public bool Add(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}