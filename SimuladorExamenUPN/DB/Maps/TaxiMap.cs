using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class TaxiMap : EntityTypeConfiguration<Taxi>
    {
        public TaxiMap()
        {
            ToTable("Taxi");
            HasKey(o => o.Id);
        }
    }
}