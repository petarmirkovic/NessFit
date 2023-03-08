using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByUsername(string username);
        bool Exists(int id);
        bool Exists(string username);
        bool Save();
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);

    }
}