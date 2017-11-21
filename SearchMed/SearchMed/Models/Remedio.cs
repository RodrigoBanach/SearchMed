using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchMed.Models
{
    public class Remedio
    {
        public long RemedioId { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }

        public long? FarmaciaId { get; set; }

        public Remedio Farmacia { get; set; }
    }
}