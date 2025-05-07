using D2R.Models;

namespace D2R.Repositories
{
    public class RoleRepository
    {
        private readonly DisasterReliefContext _context;

        public RoleRepository()
        {
            _context = new DisasterReliefContext();
        }
        public Role GetByName(string? Name)
        {
            return _context.Roles.FirstOrDefault(role => role.RoleName == Name);
        }

        public Role GetById(int id)
        {
            return _context.Roles.Find(id);
        }
    }
}
