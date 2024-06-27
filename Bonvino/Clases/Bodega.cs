using Bonvino.Clases.Actualizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases
{
    public class Bodega
    {
        public Bodega() { }
        public string nombre { get; set; }
        public string historia { get; set; }
        public List<int> coordenadasUbicacion { get; set; }
        public string descripcion { get; set; }
        public int periodoActualizacion { get; set; }
        public DateTime fechaUltimaActualizacion { get; set; }

        public bool esActualizable(DateTime fechaActual)
        {
            // Calcular la diferencia en meses entre la fecha actual y la última fecha de actualización
            int mesesDesdeUltimaActualizacion = (fechaActual.Year - fechaUltimaActualizacion.Year) * 12 + fechaActual.Month - fechaUltimaActualizacion.Month;
            // Verificar si han pasado al menos tantos meses como la periodicidad desde la última actualización
            if (mesesDesdeUltimaActualizacion > periodoActualizacion)
            {
                return true;
            }
            return false;
        }
        public Vino esTuVino(VinoActualizacion infoVinoImportado, List<Vino> vinosBD)
        {
            foreach (Vino vino in vinosBD)
            {
                if (vino.sosEsteVino(infoVinoImportado) != null)
                {
                    return vino;
                }
            }   
            return null;
        }

        public void setDatosVino(VinoActualizacion infoVinoImportado, Vino vinoAActualizar)
        {
            vinoAActualizar.fechaActualizacion = DateTime.Now;
            vinoAActualizar.imagenEtiqueta = infoVinoImportado.imagenEtiqueta;
            vinoAActualizar.precioARS = infoVinoImportado.precioARS;
            vinoAActualizar.notaDeCataBodega = infoVinoImportado.notaDeCataBodega;
        }
    }
}
