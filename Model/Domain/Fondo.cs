using Newtonsoft.Json;
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

        [MaxLength(20)]
        public string Codigo { get; set; }
        //[JsonIgnore] para que no salga en la vista

        [MaxLength(120)]
        public string RazonSocial { get; set; }

        public long AdministradoraId { get; set; }
    }
}
