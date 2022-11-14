using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISTEMADEINGRESO.Models
{
    public class Personas
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}