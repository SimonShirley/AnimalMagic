using System;
using Microsoft.EntityFrameworkCore;

namespace AnimalMagic.Data
{
    public class AnimalMagicDbContext : DbContext
    {
        private readonly DbContextOptions options;

        public AnimalMagicDbContext(DbContextOptions<AnimalMagicDbContext> options)
        {
            this.options = options;
        }
    }
}
