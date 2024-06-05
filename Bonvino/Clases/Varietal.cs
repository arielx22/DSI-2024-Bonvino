using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Varietal
    {
        public Varietal() { }
        public string descripcion { get; set; }
        public double porecentajeComposicion { get; set; }
        public TipoUva tipoUva { get; set; }
    }
}
