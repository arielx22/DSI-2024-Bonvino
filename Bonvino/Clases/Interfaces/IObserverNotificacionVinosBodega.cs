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
        void notificarNovedadVinoBodega(string bodega,List<string> vino, List<int> añada, string usuario);
    }

}
