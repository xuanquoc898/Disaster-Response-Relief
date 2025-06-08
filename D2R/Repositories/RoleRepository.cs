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
        public Role GetByName(string? Name) => _context.Roles.FirstOrDefault(role => role.RoleName == Name);

        public Role GetById(int id) => _context.Roles.Find(id);
    }
}
