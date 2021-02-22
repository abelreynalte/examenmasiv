using ExamenMasiv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMasiv.Repositories
{
    public class CodingBlastDbContext: DbContext
    {
        public CodingBlastDbContext(DbContextOptions<CodingBlastDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ruleta> Ruletas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
