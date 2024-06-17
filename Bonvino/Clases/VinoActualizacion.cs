using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class VinoActualizacion
    {
        public VinoActualizacion()
        {

        }

        public int añada { get; set; }
        public byte[] imagenEtiqueta { get; set; }
        public string nombre { get; set; }
        public string notaDeCataBodega { get; set; }
        public float precioARS { get; set; }
        public VarietalActualizacion varietal { get; set; }
        public string tipoUva {  get; set; }
        public string meridaje { get; set; }
        public Bodega bodega { get; set; }
    }
}
