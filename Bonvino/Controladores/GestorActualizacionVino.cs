using Bonvino.Boundarys;
using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Controladores
{
    public class GestorActualizacionVino
    {
        private List<Bodega> bodegas;
        private Bodega bodegaElegida;
        private List<VinoActualizacion> infoVinosImportados;
        private PantallaAtualizacionVino pantallaAtualizacionVino;
        private List<Enofilo> enofilosSeguidoresDeBodega;

        public GestorActualizacionVino(PantallaAtualizacionVino pantallaAtualizacion) {
            bodegas = new List<Bodega>();
            enofilosSeguidoresDeBodega = new List<Enofilo>();
            this.pantallaAtualizacionVino = pantallaAtualizacion;
        }
        public void opImportarActualizacionVino() {
            buscarBodegaActualizacionDisponible();
            pantallaAtualizacionVino.mostrarBodegasActualizables(bodegas);
        }
        public void buscarBodegaActualizacionDisponible()
        {
            //allBodegas hay que hardcodear, represensta las bodegas de la BD
            var allBodegas = new List<Bodega>();
            DateTime fechaActual = DateTime.Now;
            int i = 0;
            foreach (var bodega in allBodegas)
            {
                if (bodega.esActualizable(fechaActual))
                {
                    //bodegas.Add(bodega);
                    bodegas[i].nombre = bodega.nombre;
                    i++;
                }
            }
        }
        public void seleccionBodega(Bodega bodegaElegida)
        {
            this.bodegaElegida = bodegaElegida;
            buscarActualizaciones();
            var vinosActualizar = buscarVinosAActualizar();
            setOrNewVinos(vinosActualizar);
            pantallaAtualizacionVino.mostrarResumenVinosImportados();
            buscarSeguidoresBodega();
            notificar();
            finCU();
        }
        public void buscarActualizaciones()
        {
            var IAPIBodega = new InterfazAPIBodega();
            infoVinosImportados = IAPIBodega.getNovedades(bodegaElegida);
        }
        public List<VinoActualizacion> buscarVinosAActualizar()
        {
            var vinosActualizar = new List<VinoActualizacion>();
            var vinosBD = new List<Vino>();;
            foreach (var vino in infoVinosImportados)
            {
                var vinoBuscado = bodegaElegida.esTuVino(vino, vinosBD);
                if (vinoBuscado != null)
                {
                    vinosActualizar.Add(vino);
                }
            }
            return vinosActualizar;
        }
        public void setOrNewVinos(List<VinoActualizacion> vinosActualizar)
        {
            var vinosBD = new List<Vino>();
            foreach (var infoVinoImportado in infoVinosImportados)
            {

                if (vinosActualizar.Contains(infoVinoImportado))
                {
                    actualizarVinoExistente(infoVinoImportado, vinosBD);
                }
                else
                {
                    crearVino(infoVinoImportado);
                }
            }
            bodegaElegida.fechaUltimaActualizacion = DateTime.Now;
        }
        public void actualizarVinoExistente(VinoActualizacion vinoActualizacion, List<Vino> vinosBD) 
        {
            bodegaElegida.setDatosVino(vinoActualizacion, vinosBD);
        }
        public void crearVino(VinoActualizacion vinoCrear) {
            var meridaje = buscarMeridaje(vinoCrear.meridaje);
            var tipoUva = buscarTipoUva(vinoCrear.tipoUva);
            Vino vino = new Vino(meridaje,tipoUva,vinoCrear.nombre,
                vinoCrear.añada,vinoCrear.notaDeCataBodega,
                vinoCrear.precioARS,vinoCrear.imagenEtiqueta,
                vinoCrear.varietal.descripcion,vinoCrear.varietal.porcentajeComposicion);
        }
        public Meridaje buscarMeridaje(string nombre) {
            var meridajesBD = new List<Meridaje>();
            foreach (var meridajeBD in meridajesBD) {
                if (meridajeBD.sosMeridaje(nombre)) return meridajeBD;
            }
            return null;
        }
        public TipoUva buscarTipoUva(string nombre){
            var tipoUvasBD = new List<TipoUva>();
            foreach (var tipoUvaBD in tipoUvasBD)
            {
                if (tipoUvaBD.sosTipoUva(nombre)) return tipoUvaBD;
            }
            return null;
        }
        public void buscarSeguidoresBodega(){
            //enolifilos de la BD
            var enofilosBD = new List<Enofilo>();
            int i = 0;
            foreach (var enofilo in enofilosBD)
            {
                if (enofilo.seguisABodega(bodegaElegida)) {

                    enofilosSeguidoresDeBodega[i] = enofilo;
                    enofilosSeguidoresDeBodega[i].usuario.nombre = enofilo.usuario.nombre;
                    i++;
                }      
            }
        }
        public void notificar()
        {
            var INotificacionPush = new InterfazNotificacionPush();
            //falta completar el metodo notificarNovedadVinoBodega();
            foreach (var enofilo in enofilosSeguidoresDeBodega)
            {
                INotificacionPush.notificarNovedadVinoBodega(enofilo);
            }

        }
        public void finCU() 
        {
            //opcional:
            //hacer un show diagog donde pregunte si cerrar la ventana
            //si reponde que si se cierra la pantalla
            pantallaAtualizacionVino.Dispose();
        }
    }
}
