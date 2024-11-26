using Bonvino.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases.Interfaces
{
    public interface IObserverNotificacionVinosBodega
    {
        //void notificarNovedadVinoBodega(string bodega, string vino, int añada, float precioARS, string maridaje, string varietal, string tipoUva, string notaDeCata, string usuario);
        //void notificarNovedadVinoBodega(GestorActualizacionVino gestor);
        void notificarNovedadVinosBodega(string bodega, List<string> vinos, List<int> añadas, List<float> preciosARS, List<string> maridajes,
            List<float> varietales, List<string> tiposUva, List<string> notasDeCata, string usuario);
    }

}
