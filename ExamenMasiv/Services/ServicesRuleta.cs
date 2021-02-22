using ExamenMasiv.Models;
using ExamenMasiv.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMasiv.Services
{
    public class ServicesRuleta: GenericRepository<Ruleta>, IServicesRuleta
    {
        public ServicesRuleta(CodingBlastDbContext dbContext)
        : base(dbContext)
        {

        }

        public async Task<Ruleta> GetRuleta()
        {
            return await GetAll()
                .OrderByDescending(c => c.Id)
                .FirstOrDefaultAsync();
        }
    }
}
