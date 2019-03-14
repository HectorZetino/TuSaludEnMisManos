﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuSaludEnMisManos.Models
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string casaProductora { get; set; }
        public string Precio { get; set; }
        public int Existencia { get; set; }
    }
}