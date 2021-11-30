using Ecom.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecom.Data.Repository
{
    public class AbsenceRepository : BaseRepository<Absence, ApplicationDbContext>
    {
        public AbsenceRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Task<List<Absence>> FindAll()
        {
            return base.FindAll();
        }

        public override Task<Absence> Find(int id)
        {
            return base.Find(id);
        }
    }
}
