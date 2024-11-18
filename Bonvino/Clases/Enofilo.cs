using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bonvino.Clases
{
    public class Enofilo
    {
        public Enofilo() { }
        public string apellido {  get; set; }
        public byte[] imagenPerfil { get; set; }
        public string nombre { get; set; }
        public Usuario usuario { get; set; }
        public List<Siguiendo> siguiendoList { get; set; }
        public bool SeguisABodega(Bodega bodegaSeleccionada)
        {
            return siguiendoList.Any(siguiendo => siguiendo.sosDeBodega(bodegaSeleccionada));
        }

    }
}
