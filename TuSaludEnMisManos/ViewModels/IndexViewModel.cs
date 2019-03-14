using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuSaludEnMisManos.Models;

namespace TuSaludEnMisManos.ViewModels
{
    public class IndexViewModel
    {
        public List<Medicamento<int>> Medicamentos { get; set; }
    }
}