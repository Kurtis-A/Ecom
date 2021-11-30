using Ecom.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Data.Repository
{
    public class RotaRepository : BaseRepository<Rota, ApplicationDbContext>
    {
        public RotaRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Task<List<Rota>> FindAll()
        {
            return base.FindAll();
        }

        public override Task<Rota> Find(int id)
        {
            return base.Find(id);
        }
    }
}
