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
        public Varietal(TipoUva tipoUva, string descripcion, double porcentajeComposicion) { 
            this.tipoUva = tipoUva;
            this.descripcion = descripcion;
            this.porcentajeComposicion = porcentajeComposicion;
        }
        public string descripcion { get; set; }
        public double porcentajeComposicion { get; set; }
        public TipoUva tipoUva { get; set; }
    }
}
