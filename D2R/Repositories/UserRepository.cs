using D2R.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace D2R.Repositories
{
    public class UserRepository
    {
        private readonly DisasterReliefContext _context;

        public UserRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Users.Find(id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
