using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class Taxi
    {
        public int Id { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Conductor { get; set; }
        [Required]
        public string Vehiculo { get; set; }
       
    }
}