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
        private readonly IServicesRuletaDetail _servicesRuletaDet;
        public ServicesRuleta(CodingBlastDbContext dbContext, IServicesRuletaDetail servicesRuletaDetail)
        : base(dbContext)
        {
            _servicesRuletaDet = servicesRuletaDetail;
        }

        public async Task<List<Ruleta>> Get()
        {
            var identifier = Guid.NewGuid();
            try
            {
                return await GetAll()
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
                var entity = await Create(ruleta);
                short colourid = 1;
                int[] arr = Util.generateNoRepeatingRandomNumbers(30, 1, 30);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (colourid == 1) colourid = 2; else colourid = 1;
                    var ruletaDet = new RuletaDetail() {
                        RuletaId = entity.Id,
                        Number = arr[i],
                        ColourId = colourid,
                        Amount = Convert.ToDecimal(Util.generateNumberRandom(1, 10000))
                    };
                    var entitydetail = await _servicesRuletaDet.Save(ruletaDet);
                }

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
