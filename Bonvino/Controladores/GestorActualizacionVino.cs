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
        public List<Vino> seleccionBodega(Bodega bodegaElegida)
        {
            this.bodegaElegida = bodegaElegida;
            /*Falta Completar, devuelve novedeasdes de información 
             * de vinos y no objeto*/
            buscarActualizaciones();
            buscarVinosAActualizar(infoVinosImportados);
            return infoVinosImportados;
        }
        public void buscarActualizaciones()
        {
            //falta completar tema de la API
            //Verificar bien el tema de la API y Boundary
            var IAPIBodega = new InterfazAPIBodega();
            infoVinosImportados = IAPIBodega.getNovedades();   
        }
        public void buscarVinosAActualizar(List<Vino> infoVinosImportados)
        {
            var Vinos = new List<Vino>();
            foreach (var vino in infoVinosImportados)
            {

            }
        }


    }
}
