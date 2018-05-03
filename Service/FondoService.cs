using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class FondoService : Service<Fondo>
    {
        public FondoService(CloudContext context) 
            : base(context)
        {
        }

        public Task<Fondo> FindByCodigoAsync(string codigo)
        {
            return
                Entity
                    .Where(e => e.Codigo == codigo)
                    .SingleOrDefaultAsync();
        }
    }
}
