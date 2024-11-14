using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases.Interfaces
{
    public interface IObserverNotificacionVinosBodega
    {
        void actualizar(string bodega, string vino, int añada, float precioARS, string maridaje, string varietal, string tipoUva, string notaDeCata, List<string> usuario);
        void notificarNovedadVinoBodega();
    }
}
