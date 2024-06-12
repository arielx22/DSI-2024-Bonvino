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
        private List<Vino> infoVinosImportados;

        public GestorActualizacionVino() {
            bodegas = new List<Bodega>();
        }
        public List<Bodega> opImportarActualizacionVino() { 
            return buscarBodegaActualizacionDisponible();
        }
        public List<Bodega> buscarBodegaActualizacionDisponible()
        {
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
            return bodegas;
        }
        public void seleccionBodega(Bodega bodegaElegida)
        {
            this.bodegaElegida = bodegaElegida;
            /*Falta Completar, devuelve novedeasdes de información 
             * de vinos y no objeto*/
            buscarActualizaciones();
            var VinosActualizar = buscarVinosAActualizar();
            setOrNewVinos(VinosActualizar);

        }
        public void buscarActualizaciones()
        {
            //falta completar tema de la API
            //Verificar bien el tema de la API y Boundary
            var IAPIBodega = new InterfazAPIBodega();
            infoVinosImportados = IAPIBodega.getNovedades();
        }
        public List<Vino> buscarVinosAActualizar()
        {
            var vinosActualizar = new List<Vino>();
            var vinosBD = new List<Vino>();
            foreach (var vino in infoVinosImportados)
            {
                var vinoBuscado = bodegaElegida.esTuVino(vino, vinosBD);
                if (vinoBuscado != null)
                {
                    vinosActualizar.Add(vinoBuscado);
                }
            }
            return vinosActualizar;
        }
        public void setOrNewVinos(List<Vino> vinosActualizar)
        {
            foreach (var vino in infoVinosImportados)
            {
                if (vinosActualizar.Contains(vino))
                {
                    actualizarVinoExistente(vino);
                }
                else
                {
                    crearVino(vino);
                }
            }
        }
        public void actualizarVinoExistente(Vino vino) 
        {

        }
        public void crearVino(Vino vino) { }
        public void buscarMeridaje() { }
        public void buscarTipoUva(){}
        public void buscarSeguidoresBodega(){}
        public void finCU() { }
    }
}
