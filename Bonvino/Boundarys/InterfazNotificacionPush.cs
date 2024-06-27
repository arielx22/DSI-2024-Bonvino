using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonvino.Boundarys
{
    public class InterfazNotificacionPush
    {
        public InterfazNotificacionPush() { }
        public void notificarNovedadVinoBodega(List<Enofilo> listaEnofilosSuscriptos)
        {
            StringBuilder nombresEnofilos = new StringBuilder("Se le notifico a los usuarios enofilos:\n");

            foreach (var enofilo in listaEnofilosSuscriptos)
            {
                nombresEnofilos.AppendLine($"{enofilo.nombre} - {enofilo.usuario.nombre}");
            }

            MessageBox.Show(nombresEnofilos.ToString(), "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
