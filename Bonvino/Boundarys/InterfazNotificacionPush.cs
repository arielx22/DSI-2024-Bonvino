using Bonvino.Clases;
using Bonvino.Clases.Interfaces;
using Bonvino.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonvino.Boundarys
{
    public class InterfazNotificacionPush : IObserverNotificacionVinosBodega
    {
        //private List<string> notificaciones = new List<string>();

        //private List<string> vinosNotificados = new List<string>();
        //private List<string> usuariosNotificados = new List<string>();
        public InterfazNotificacionPush() { }
        //Analisis
        /*public void notificarNovedadVinoBodega(List<Enofilo> listaEnofilosSuscriptos)
        {
            StringBuilder nombresEnofilos = new StringBuilder("Se le notifico a los usuarios enofilos:\n");

            foreach (var enofilo in listaEnofilosSuscriptos)
            {
                nombresEnofilos.AppendLine($"{enofilo.nombre} - {enofilo.usuario.nombre}");
            }

            MessageBox.Show(nombresEnofilos.ToString(), "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/
        public void notificarNovedadVinoBodega(string bodega,List<string> vino, List<int> añada, string usuario)
        {
            StringBuilder mensaje = new StringBuilder();

            // Notificar al usuario
            mensaje.AppendLine($"Se notificó a {usuario} lo siguiente:");

            // Nombre de la bodega
            mensaje.AppendLine($"Bodega: {bodega}");

            // Listado de vinos y añadas
            mensaje.AppendLine("Vinos y añada:");
            for (int i = 0; i < vino.Count; i++)
            {
                mensaje.AppendLine($"- {vino[i]} (Añada: {añada[i]})");
            }

            // Mostrar la notificación en un MessageBox o consola (dependiendo del contexto)
            MessageBox.Show(mensaje.ToString(), "Notificación de Actualización de Vinos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }
}
