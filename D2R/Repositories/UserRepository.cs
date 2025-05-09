using D2R.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

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
            return _context.Users.Include(u => u.Role)
                .Include(u => u.Warehouse)
                .ThenInclude(w => w.Area)
                .ToList();
        }
        public User GetByUsername(string username)
        {
            return _context.Users.Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);
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

        public void Delete(string username)
        {
            var entity = _context.Users.FirstOrDefault(u => u.Username == username);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<User> GetStaffsByAreaId(int areaId)
        {
            return _context.Users
                .Where(u => u.RoleId == 2 && u.AreaId == areaId)
                .ToList();
        }

        public List<User> GetAdmins()
        {
            return _context.Users
                .Where(u => u.RoleId == 1)
                .ToList();
        }
    }
}
