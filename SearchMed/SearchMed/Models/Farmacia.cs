﻿using System;
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
        public long Telefone { get; set; }


        public virtual ICollection<Remedio> Remedios { get; set; }

    }
}