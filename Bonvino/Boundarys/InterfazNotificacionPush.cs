using Bonvino.Clases;
using Bonvino.Clases.Interfaces;
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

        private List<string> vinosNotificados = new List<string>();
        private List<string> usuariosNotificados = new List<string>();

        /*public string bodega { get; set; }
        public string vino { get; set; }
        public int añada { get; set; }
        public float precioARS { get; set; }
        public string maridaje { get; set; }
        public string varietal { get; set; }
        public string tipoUva { get; set; }
        public string notaDeCata { get; set; }
        public string usuario { get; set; }*/
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
        public void actualizar(string bodega, string vino, int añada, float precioARS, string maridaje, string varietal, string tipoUva, string notaDeCata, List<string> usuarios)
        {
            /*this.bodega = bodega;
            this.vino = vino;
            this.añada = añada;
            this.precioARS = precioARS;
            this.maridaje = maridaje;
            this.varietal = varietal;
            this.tipoUva = tipoUva;
            this.notaDeCata = notaDeCata;
            this.usuario = usuario;*/
            // Almacena la información del vino
            vinosNotificados.Add($"Bodega: {bodega}, Vino: {vino}, Añada: {añada}, Precio: {precioARS}, Maridaje: {maridaje}, Varietal: {varietal}, Tipo Uva: {tipoUva}, Nota de Cata: {notaDeCata}");
            // Almacena el usuario, evitando duplicados
            this.usuariosNotificados = usuarios;
            notificarNovedadVinoBodega();
        }
        public void notificarNovedadVinoBodega() {

            StringBuilder mensaje = new StringBuilder("Estos vinos con sus datos fueron notificados a los siguientes usuarios enófilos:\n\n");

            // Agregar información de los vinos
            foreach (var vinoInfo in vinosNotificados)
            {
                mensaje.AppendLine(vinoInfo);
            }

            // Agregar usuarios notificados
            mensaje.AppendLine("\nUsuarios notificados:");
            foreach (var usuario in usuariosNotificados)
            {
                mensaje.AppendLine(usuario);
            }

            MessageBox.Show(mensaje.ToString(), "Notificación de Vinos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar las listas después de mostrarlas
            vinosNotificados.Clear(); 

        }


    }
}
