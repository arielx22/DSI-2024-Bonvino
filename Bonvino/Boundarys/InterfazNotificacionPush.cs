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
        public void notificarNovedadVinosBodega( string bodega, List<string> vinos, List<int> añadas, List<float> preciosARS, List<string> maridajes, 
            List<float> varietales, List<string> tiposUva, List<string> notasDeCata, string usuario)
        {
            StringBuilder mensaje = new StringBuilder();

            // Notificar al usuario
            mensaje.AppendLine($"Se notificó a {usuario} lo siguiente:");

            // Nombre de la bodega
            mensaje.AppendLine($"Bodega: {bodega}");

            // Listado de vinos y añadas
            mensaje.AppendLine("Vinos y añadas:");
            for (int i = 0; i < vinos.Count; i++)
            {
                mensaje.AppendLine($"- {vinos[i]} (Añada: {añadas[i]})");

                // Precio en ARS
                if (preciosARS != null && preciosARS.Count > i)
                {
                    mensaje.AppendLine($"  Precio ARS: {preciosARS[i]:0.00}"); // Mostrar precio con dos decimales
                }

                // Maridaje
                if (maridajes != null && maridajes.Count > i)
                {
                    mensaje.AppendLine($"  Maridaje: {(string.IsNullOrEmpty(maridajes[i]) ? "Sin maridaje" : maridajes[i])}");
                }

                // Varietal y Tipo de Uva
                if (varietales != null && varietales.Count > i)
                {
                    mensaje.AppendLine($"  Varietal: {varietales[i]:0.00}%");
                }
                if (tiposUva != null && tiposUva.Count > i)
                {
                    mensaje.AppendLine($"  Tipo de Uva: {tiposUva[i]}");
                }

                // Nota de cata de bodega
                if (notasDeCata != null && notasDeCata.Count > i)
                {
                    mensaje.AppendLine($"  Nota de Cata Bodega: {(string.IsNullOrEmpty(notasDeCata[i]) ? "Sin nota de cata" : notasDeCata[i])}");
                }
                
            }

            // Mostrar la notificación en un MessageBox o consola (dependiendo del contexto)
            MessageBox.Show(mensaje.ToString(), "Notificación de Actualización de Vinos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
