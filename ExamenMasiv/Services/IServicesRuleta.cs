using ExamenMasiv.Models;
using ExamenMasiv.Repositories;
using System.Threading.Tasks;

namespace ExamenMasiv.Services
{
    public interface IServicesRuleta: IGenericRepository<Ruleta>
    {
        Task<Ruleta> Get();
        Task<Ruleta> Save(Ruleta ruleta);
    }
}
