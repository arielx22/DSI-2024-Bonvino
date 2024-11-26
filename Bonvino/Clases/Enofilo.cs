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
        private string apellido;
        private byte[] imagenPerfil;
        private string nombre;
        private Usuario usuario;
        private List<Siguiendo> siguiendo;

        public Enofilo() { }

        public string getApellido()
        {
            return apellido;
        }

        public void setApellido(string apellido)
        {
            this.apellido = apellido;
        }

        public byte[] getImagenPerfil()
        {
            return imagenPerfil;
        }

        public void setImagenPerfil(byte[] imagenPerfil)
        {
            this.imagenPerfil = imagenPerfil;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public Usuario getUsuario()
        {
            return usuario;
        }

        public void setUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public List<Siguiendo> getSiguiendoList()
        {
            return siguiendo;
        }

        public void setSiguiendo(List<Siguiendo> siguiendoList)
        {
            this.siguiendo = siguiendoList;
        }
        public bool SeguisABodega(Bodega bodegaSeleccionada)
        {
            return siguiendo.Any(siguiendo => siguiendo.sosDeBodega(bodegaSeleccionada));
        }

    }
}
