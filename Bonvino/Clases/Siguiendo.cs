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
        private DateTime fechaInicio;
        private DateTime fechaFin;

        public Siguiendo() { }

        public DateTime getFechaInicio()
        {
            return fechaInicio;
        }

        public void setFechaInicio(DateTime fechaInicio)
        {
            this.fechaInicio = fechaInicio;
        }

        public DateTime getFechaFin()
        {
            return fechaFin;
        }

        public void setFechaFin(DateTime fechaFin)
        {
            this.fechaFin = fechaFin;
        }
        public Bodega getBodega() 
        { 
            return bodega;
        }
        public void setBodega(Bodega value)
        {
            if (value != null)
            {
                enofilo = null; // Si se asigna una Bodega, Enofilo se establece en null
            }
            bodega = value;
        }

        public Enofilo getEnofilo()
        {
            return enofilo;
        }

        public void setEnofilo(Enofilo value)
        {
            if (value != null)
            {
                bodega = null; // Si se asigna un Enofilo, Bodega se establece en null
            }
            enofilo = value;
        }
        public bool sosDeBodega(Bodega bodega) {
            if (this.bodega.getNombre() == bodega.getNombre())
            {
                return true;
            }
            return false;
        }
    }
}
