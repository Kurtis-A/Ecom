using Ecom.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecom.Data.Repository
{
    public class StaffRepository : BaseRepository<Staff, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override Task<List<Staff>> FindAll()
        {
            return base.FindAll();
        }

        public override Task<Staff> Find(int id)
        {
            return base.Find(id);
        }
    }
}
