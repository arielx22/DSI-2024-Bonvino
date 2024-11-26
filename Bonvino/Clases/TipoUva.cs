using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class TipoUva
    {
        // Atributos privados
        private string descripcion;
        private string nombre;

        // Constructor
        public TipoUva() { }

        // Propiedad pública para acceder y modificar 'descripcion'

        public string getDescripcion()
        {
            return descripcion;
        }

        // Método set para 'descripcion'
        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        // Método get para 'nombre'
        public string getNombre()
        {
            return nombre;
        }

        // Método set para 'nombre'
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public bool sosTipoUva(string nombre) { 
            return this.nombre == nombre;
        }
    }
}
