using Bonvino.Clases.Actualizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Vino
    {
        private int añada;
        private DateTime fechaActualizacion;
        private byte[] imagenEtiqueta;
        private string nombre;
        private string notaDeCataBodega;
        private float precioARS;
        private Varietal varietal;
        private Maridaje maridaje;
        private Bodega bodega;

        public Vino() { }

        public Vino(Maridaje maridaje, TipoUva tipoUva, string nombre, int añada,
                    string notaDeCataBodega, float precioARS, string descripcion,
                    float porcentajeComposicion, Bodega bodega)
        {
            this.maridaje = maridaje;
            this.nombre = nombre;
            this.añada = añada;
            this.notaDeCataBodega = notaDeCataBodega;
            this.precioARS = precioARS;
            this.bodega = bodega;
            this.fechaActualizacion = DateTime.Now.Date;
            crearVarietal(tipoUva, descripcion, porcentajeComposicion);
        }

        public int getAñada()
        {
            return añada;
        }

        public void setAñada(int añada)
        {
            this.añada = añada;
        }

        public DateTime getFechaActualizacion()
        {
            return fechaActualizacion;
        }

        public void setFechaActualizacion(DateTime fechaActualizacion)
        {
            this.fechaActualizacion = fechaActualizacion;
        }

        public byte[] getImagenEtiqueta()
        {
            return imagenEtiqueta;
        }

        public void setImagenEtiqueta(byte[] imagenEtiqueta)
        {
            this.imagenEtiqueta = imagenEtiqueta;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNotaDeCataBodega()
        {
            return notaDeCataBodega;
        }

        public void setNotaDeCataBodega(string notaDeCataBodega)
        {
            this.notaDeCataBodega = notaDeCataBodega;
        }

        public float getPrecioARS()
        {
            return precioARS;
        }

        public void setPrecioARS(float precioARS)
        {
            this.precioARS = precioARS;
        }

        public Varietal getVarietal()
        {
            return varietal;
        }

        public void setVarietal(Varietal varietal)
        {
            this.varietal = varietal;
        }

        public Maridaje getMaridaje()
        {
            return maridaje;
        }

        public void setMaridaje(Maridaje maridaje)
        {
            this.maridaje = maridaje;
        }

        public Bodega getBodega()
        {
            return bodega;
        }

        public void setBodega(Bodega bodega)
        {
            this.bodega = bodega;
        }

        private void crearVarietal(TipoUva tipoUva, string descripcion, float porcentajeComposicion)
        {
            this.varietal = new Varietal(tipoUva, descripcion, porcentajeComposicion);
        }
        public Vino sosEsteVino(VinoActualizacion vinoImportado)
        {
            if (this.nombre == vinoImportado.nombre && this.añada == vinoImportado.añada) return this;
          
            return null;
        }
        public bool sosVinoAActualizar(string nombre, int añada)
        {
            if (this.nombre == nombre && this.añada == añada) return true;
            return false;
        }
    }
}
