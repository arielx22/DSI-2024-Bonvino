using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Usuario
    {
        // Atributos privados
        private string contraseña;
        private string nombre;
        private Boolean premium;

        // Constructor
        public Usuario() { }
        public string getContraseña()
        {
            return contraseña;
        }
        public void setContraseña(string contraseña)
        {
            this.contraseña = contraseña;
        }
        public string getNombre()
        {
            return nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public Boolean getPremium()
        {
            return premium;
        }
        public void setPremium(Boolean premium)
        {
            this.premium = premium;
        }

    }
}
