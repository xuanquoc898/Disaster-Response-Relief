using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class RoleRepository
    {
        private readonly DisasterReliefContext _context;

        public RoleRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetByName(string Name)
        {
            return _context.Roles.FirstOrDefault(role => role.RoleName == Name );
        }

        public Role GetById(int id)
        {
            return _context.Roles.Find(id);
        }

        public void Add(Role entity)
        {
            _context.Roles.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Roles.Find(id);
            if (entity != null)
            {
                _context.Roles.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
