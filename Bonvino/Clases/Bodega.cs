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
        public string nombre {  get; set; }
        public string historia { get; set; }
        public List<int> coordenadasUbicacion { get; set;}
        public string descripcion { get; set; }
        public TimeSpan periodoActualizacion { get; set; }
        public DateTime fechaUltimaActualizacion { get; set; }

        public bool esActualizable(DateTime fechaActual)
        {
            int diasDelPeriodo = periodoActualizacion.Days;
            return fechaActual.Day <= diasDelPeriodo;
        }
        public Vino esTuVino(Vino vinoImportado, List<Vino> vinos)
        {
            foreach (Vino vino in vinos)
            {
                if (vino.sosEsteVino(vinoImportado) == null) {
                    return null;
                }
                return vino.sosEsteVino(vinoImportado);
            }
            return null;
        }
    }
}
