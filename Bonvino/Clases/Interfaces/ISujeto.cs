using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Clases.Interfaces
{
    public interface ISujeto
    {
        List<IObserverNotificacionVinosBodega> elementos { get; set; }
        void suscribir(IObserverNotificacionVinosBodega observador);
        void quitar(IObserverNotificacionVinosBodega observador);
        void notificar();
    }
}
