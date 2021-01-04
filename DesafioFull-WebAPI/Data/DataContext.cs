using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DesafioFull_WebAPI.Models;
using System;

namespace DesafioFull_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Divida> Dividas { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Divida>()
                .HasData(new List<Divida>(){
                    new Divida(1, 1234, "Antonio", "12345612348", 2, 3, 2),
                });

            builder.Entity<Parcela>()
                .HasData(new List<Parcela>{
                    new Parcela(1, 1, DateTime.ParseExact("08-05-2019", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), 95.5m, 1),
                    new Parcela(2, 2, DateTime.ParseExact("08-05-2019", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), 96m, 1),
                });
        }
    }
}