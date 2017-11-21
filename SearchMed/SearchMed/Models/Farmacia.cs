using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchMed.Models
{
    public class Farmacia
    {
        public long FarmaciaId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int CNPJ { get; set; }
        public int Telefone { get; set; }

        public long? RemedioId { get; set; }

        public Remedio Remedio { get; set; }

    }
}