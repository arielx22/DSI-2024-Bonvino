using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Maridaje
    {
        private string descripcion;
        private string nombre;
        public Maridaje() { }
        public string getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public bool sosMaridaje(string nombre) {
            return this.nombre == nombre;
        }
    }
}
