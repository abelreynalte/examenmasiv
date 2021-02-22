using ExamenMasiv.Helpers;
using ExamenMasiv.Models;
using ExamenMasiv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMasiv.Services
{
    public class ServicesRuletaDetail: GenericRepository<RuletaDetail>, IServicesRuletaDetail
    {
        public ServicesRuletaDetail(CodingBlastDbContext dbContext)
        : base(dbContext)
        {

        }
        public async Task<RuletaDetail> Save(RuletaDetail ruleta)
        {
            var identifier = Guid.NewGuid();
            try
            {
                var entity = await Create(ruleta);
                return entity;
            }
            catch (Exception ex)
            {
                new LoggerCloudWatch().RegisterLogFatal(ex, identifier);
                throw;
            }
        }
    }
}
