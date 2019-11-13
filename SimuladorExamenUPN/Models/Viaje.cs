using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class Viaje
    {
        public int Id { get; set; }
        [Required]
        public String Persona { get; set; }
        [Required]
        public String Origen { get; set; }
        [Required]
        public String Destino { get; set; }
        [Required]
        public int TaxiId { get; set; }
        [Required]
        public String Conductor { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}