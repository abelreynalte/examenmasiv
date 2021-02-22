using ExamenMasiv.Helpers;
using ExamenMasiv.Models;
using ExamenMasiv.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<Ruleta>> Get()
        {
            var identifier = Guid.NewGuid();
            try
            {
                return await GetAll()
                //.OrderByDescending(c => c.Id)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                new LoggerCloudWatch().RegisterLogFatal(ex, identifier);
                throw;
            }            
        }
        public async Task<Ruleta> Save(Ruleta ruleta)
        {
            var identifier = Guid.NewGuid();
            try
            {
                return await Create(ruleta);
            }
            catch (Exception ex)
            {
                new LoggerCloudWatch().RegisterLogFatal(ex, identifier);
                throw;
            }            
        }
    }
}
