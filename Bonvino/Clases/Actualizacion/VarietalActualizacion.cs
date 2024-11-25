using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases.Actualizacion
{
    public class VarietalActualizacion
    {
        public VarietalActualizacion() { }
        public string descripcion { get; set; }
        public float porcentajeComposicion { get; set; }
        public TipoUvaActualizacion tipoUva { get; set; }
    }
}
