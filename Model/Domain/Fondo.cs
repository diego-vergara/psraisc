using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Domain
{
    public class Fondo
    {
        [Key]
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
    }
}
