using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class TemaMap: EntityTypeConfiguration<Tema>
    {
        public TemaMap()
        {
            ToTable("Tema");
            HasKey(o => o.Id);

            HasRequired(o => o.Categoria)
             .WithMany()
             .HasForeignKey(o => o.Id);


            //Property(o => o.Nombre).HasColumnName("Nombre");
        }
    }
}