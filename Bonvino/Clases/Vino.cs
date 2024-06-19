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
        public Vino() { }
        public Vino(Maridaje maridaje,TipoUva tipoUva, string nombre, int añada, 
            string notaDeCataBodega, float precioARS, string descripcion,
            double porcentajeComposicion) {
            this.maridaje = maridaje;
            this.nombre = nombre;
            this.añada = añada;
            this.notaDeCataBodega = notaDeCataBodega;
            this.precioARS = precioARS;
            crearVarietal(tipoUva, descripcion, porcentajeComposicion);
        }
        public int añada { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public byte[] imagenEtiqueta { get; set; }
        public string nombre { get; set; }
        public string notaDeCataBodega { get; set; }
        public float precioARS { get; set; }
        public Varietal varietal { get; set; }
        public Maridaje maridaje { get; set; }
        public Bodega bodega { get; set; }
        public void crearVarietal(TipoUva tipoUva, string descripcion, double porcentajeComposicion)
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
