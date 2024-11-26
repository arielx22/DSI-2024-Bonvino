using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Varietal
    {
        private TipoUva tipoUva;
        private string descripcion;
        private float porcentajeComposicion;

        public Varietal() { }

        public Varietal(TipoUva tipoUva, string descripcion, float porcentajeComposicion)
        {
            this.tipoUva = tipoUva;
            this.descripcion = descripcion;
            this.porcentajeComposicion = porcentajeComposicion;
        }
        public string getDescripcion()
        {
            return descripcion;
        }
        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }
        public float getPorcentajeComposicion()
        {
            return porcentajeComposicion;
        }
        public void setPorcentajeComposicion(float porcentajeComposicion)
        {
            this.porcentajeComposicion = porcentajeComposicion;
        }
        public TipoUva getTipoUva()
        {
            return tipoUva;
        }
        public void setTipoUva(TipoUva tipoUva)
        {
            this.tipoUva = tipoUva;
        }
    }
}
