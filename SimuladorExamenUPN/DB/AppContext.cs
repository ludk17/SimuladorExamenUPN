using SimuladorExamenUPN.DB.Maps;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB
{
    public class AppContext : DbContext
    {
        public IDbSet<Tema> Temas { get; set; }

        public AppContext()
        {
            Database.SetInitializer<AppContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TemaMap());
        }
    }
}