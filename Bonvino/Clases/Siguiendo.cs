using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Siguiendo
    {
        private Bodega bodega;
        private Enofilo enofilo;
        public Siguiendo() { }
        public DateTime fechaInicio {  get; set; }
        public DateTime fechaFin { get; set; }
        public Bodega bodegaME
        {
            get => bodega;
            set
            {
                if (value != null)
                {
                    enofilo = null; // Si se asigna una Bodega, Enofilo se establece en null
                }
                bodega = value;
            }
        }
        public Enofilo enofiloME
        {
            get => enofilo;
            set
            {
                if (value != null)
                {
                    bodega = null; // Si se asigna un Enofilo, Bodega se establece en null
                }
                enofilo = value;
            }
        }
        public bool sosDeBodega(Bodega bodega) {
            if (this.bodega==null) {
                return false;
            }
            return this.bodega == bodega;
        }
    }
}
