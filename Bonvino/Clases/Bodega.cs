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
        private string nombre;
        private string historia;
        private List<float> coordenadasUbicacion;
        private string descripcion;
        private int periodoActualizacion;
        private DateTime fechaUltimaActualizacion;
        public Bodega() { }
        public string getNombre()
        {
            return nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string getHistoria()
        {
            return historia;
        }
        public void setHistoria(string historia)
        {
            this.historia = historia;
        }
        public List<float> getCoordenadasUbicacion()
        {
            return coordenadasUbicacion;
        }
        public void setCoordenadasUbicacion(List<float> coordenadasUbicacion)
        {
            this.coordenadasUbicacion = coordenadasUbicacion;
        }
        public string getDescripcion()
        {
            return descripcion;
        }
        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }
        public int getPeriodoActualizacion()
        {
            return periodoActualizacion;
        }
        public void setPeriodoActualizacion(int periodoActualizacion)
        {
            this.periodoActualizacion = periodoActualizacion;
        }
        public DateTime getFechaUltimaActualizacion()
        {
            return fechaUltimaActualizacion;
        }
        public void setFechaUltimaActualizacion(DateTime fechaUltimaActualizacion)
        {
            this.fechaUltimaActualizacion = fechaUltimaActualizacion;
        }
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
            vinoAActualizar.setFechaActualizacion(DateTime.Now.Date);
            vinoAActualizar.setImagenEtiqueta(infoVinoImportado.imagenEtiqueta);
            vinoAActualizar.setPrecioARS(infoVinoImportado.precioARS);
            vinoAActualizar.setNotaDeCataBodega(infoVinoImportado.notaDeCataBodega);
        }
    }
}
