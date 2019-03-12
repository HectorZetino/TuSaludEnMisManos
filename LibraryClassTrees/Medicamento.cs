using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuSaludEnMisManos.Models
{
    public class Medicamento<T>
    {
        public T Id_medicamento { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string casa_productora { get; set; }
        public string precio { get; set; }
        public int existencia { get; set; }
    }
}