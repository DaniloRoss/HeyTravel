using HeyTravel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Viaggio> eleViaggi { get; set; }
        public DbSet<Associazione> eleAssociazione { get; set; }

        //AGGIUNGERE I DBSET DI VACCINI, METEO E CASI
    }
}
