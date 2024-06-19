using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Maridaje
    {
        public Maridaje() { }
        public string descripcion {  get; set; }
        public string nombre { get; set; }

        public bool sosMaridaje(string nombre) {
            return this.nombre == nombre;
        }
    }
}
