using ExamenMasiv.Models;
using System.Threading.Tasks;

namespace ExamenMasiv.Services
{
    public interface IServicesRuletaDetail
    {
        Task<RuletaDetail> Save(RuletaDetail ruletaDet);
    }
}
