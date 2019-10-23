using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class ProductoMap: EntityTypeConfiguration<Producto>
    {
        public ProductoMap()
        {
            ToTable("Producto");
            HasKey(o => o.Id);
        }
    }
}