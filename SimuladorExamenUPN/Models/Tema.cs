using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class Tema
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public List<Pregunta> Preguntas { get; set; }
       
        public Categoria Categoria { get; set; }

    }
}