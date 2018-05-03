using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Domain
{
    public class Administradora
    {
        public long Id { get; set; }

        [MaxLength(120)]
        public string Nombre { get; set; }

        [MaxLength(8)]
        public int Rut { get; set; }

        [MaxLength(1)]
        public string Dv { get; set; }

        public ICollection<Fondo> Fondo { get; set; }
    }
}
