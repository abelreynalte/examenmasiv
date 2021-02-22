using ExamenMasiv.Models;
using ExamenMasiv.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamenMasiv.Services
{
    public interface IServicesRuleta: IGenericRepository<Ruleta>
    {
        Task<List<Ruleta>> Get();
        Task<Ruleta> Save(Ruleta ruleta);
    }
}
