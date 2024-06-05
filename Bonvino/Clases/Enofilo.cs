using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Enofilo
    {
        public Enofilo() { }
        public string apellido {  get; set; }
        public byte[] imagenPerfil { get; set; }
        public string nombre { get; set; }
        public Usuario usuario { get; set; }
        public Siguiendo siguiendo { get; set; }
    }
}
