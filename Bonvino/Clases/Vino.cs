using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Vino
    {
        public Vino() { }
        public string añada { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public byte[] imagenEtiqueta { get; set; }
        public string nombre { get; set; }
        public string notaDeCataBodega { get; set; }
        public float precioARS { get; set; }
        public Varietal varietal { get; set; }
        public Meridaje meridaje { get; set; }
        public Bodega bodega { get; set; }

        public Vino sosEsteVino(Vino vinoImportado)
        {
            if(this.nombre == vinoImportado.nombre) return this;
            return null;
        }
    }
}
