using SimuladorExamenUPN.DB.Maps;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB
{
    public class SimuladorContext : DbContext
    {
        public IDbSet<Tema> Temas { get; set; }
        public IDbSet<Pregunta> Preguntas { get; set; }
        public IDbSet<Alternativa> Alternativas { get; set; }

        //public SimuladorContext()
        //{
        //    Database.SetInitializer<SimuladorContext>(null);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TemaMap());
            modelBuilder.Configurations.Add(new PreguntaMap());
            modelBuilder.Configurations.Add(new AlternativaMap());
        }
    }
}