using Bonvino.Boundarys;
using Bonvino.Clases;
using Bonvino.Clases.Actualizacion;
using Bonvino.Clases.Interfaces;
using Bonvino.Persistencia.Repositorio;
using Bonvino.Pesistecia.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonvino.Controladores
{
    public class GestorActualizacionVino : ISujeto
    {
        private List<Bodega> bodegas;
        private Bodega bodegaElegida;
        private List<VinoActualizacion> infoVinosImportados;
        private List<Enofilo> enofilosSeguidoresDeBodega;
        private List<string> usuarios;
        private List<Vino> vinos;
        private List<string> nombreVinos;
        private List<int> añadaVinos;

        private List<float> precioARSVinos;
        private List<string> maridajeVinos;
        private List<float> varietalVinos;
        private List<string> tipoUvaVinos;
        private List<string> notaDeCataVinos;

        //implementación del atributo elementos de ISujeto
        public List<IObserverNotificacionVinosBodega> elementos { get; set; }

        //persistencia
        private BodegaRepositorio bodegaRepositorio;
        private VinoRepositorio vinoRepositorio;
        private MaridajeRepositorio maridajeRepositorio;
        private VarietalRepositorio varietalRepositorio;
        private TipoUvaRepositorio tipoUvaRepositorio;
        private UsuarioRepositorio usuarioRepositorio;
        private EnofiloRepositorio enofilosRepositorio;
        private SiguiendoRepositorio siguiendoRepositorio;

        public GestorActualizacionVino() {
            bodegas = new List<Bodega>();
            enofilosSeguidoresDeBodega = new List<Enofilo>();
            elementos = new List<IObserverNotificacionVinosBodega>();
            vinos = new List<Vino>();

            usuarios = new List<string>();
            nombreVinos = new List<string>();
            añadaVinos = new List<int>();
            precioARSVinos = new List<float>();
            maridajeVinos = new List<string>();
            varietalVinos = new List<float>();
            tipoUvaVinos = new List<string>();
            notaDeCataVinos = new List<string>();

            bodegaRepositorio = new BodegaRepositorio();
            vinoRepositorio = new VinoRepositorio();
            maridajeRepositorio = new MaridajeRepositorio();
            varietalRepositorio = new VarietalRepositorio();
            tipoUvaRepositorio = new TipoUvaRepositorio();
            enofilosRepositorio = new EnofiloRepositorio();
            usuarioRepositorio = new UsuarioRepositorio();
            siguiendoRepositorio = new SiguiendoRepositorio();
        }
        public void opImportarActualizacionVino(PantallaAtualizacionVino pantallaAtualizacionVino) {
            buscarBodegaActualizacionDisponible();
            //A1 No hay bodegas con actualizaciones.
            if (bodegas.Count == 0) 
                MessageBox.Show("No hay bodegas con actualizaciones disponibles.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else pantallaAtualizacionVino.mostrarBodegasActualizables(bodegas);

        }
        //Analisis
        public void buscarBodegaActualizacionDisponible()
        {
            //Para que no se repitan las bodegas en la lista, 
            //cuando se hace click en el boton importar.
            bodegas.Clear();
            //var bodegasBD = getBodegasSinBD(); //Analisis
            var bodegasBD = bodegaRepositorio.ObtenerBodegas();
            DateTime fechaActual = DateTime.Now;
            int i = 0;
            foreach (var bodega in bodegasBD)
            {
                if (bodega.esActualizable(fechaActual))
                {
                    bodegas.Add(bodega);
                    bodegas[i].setNombre(bodega.getNombre());
                    i++;
                }
            }
        }

        public void seleccionBodega(Bodega bodegaElegida, PantallaAtualizacionVino pantallaAtualizacionVino)
        {
            this.bodegaElegida = bodegaElegida;
            // A3: Buscar actualizaciones en la API externa
            try
            {
                buscarActualizaciones();
            }
            catch (Exception ex)
            {
                // Si falla la API externa, interrumpimos el flujo.
                MessageBox.Show($"El sistema externo de bodegas no dio respuesta. Error: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Detener la operación
            }

            setOrNewVinos(pantallaAtualizacionVino);
            //CASO Alternativo: Verificar si no se actualizaron o crearon vinos
            if (vinos.Count == 0)
            {
                MessageBox.Show("No hay actualizaciones o nuevos vinos para la bodega seleccionada.", "Sin Actualizaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;  // Detener la operación si no hay actualizaciones
            }
            buscarSeguidoresBodega();
            if (usuarios.Count == 0)
            {
                // A2 Si no hay seguidores, interrumpimos el flujo.
                MessageBox.Show("La bodega seleccionada no tiene seguidores para recibir la notificación.", "Sin Seguidores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;  // Detener la operación
            }
            var iNotificacionPush = new InterfazNotificacionPush(); //new(): interfazNotificacionPush
            suscribir(iNotificacionPush);
            notificar();
            finCU();
        }
        public void buscarActualizaciones()
        {
            try
            {
                var IAPIBodega = new InterfazAPIBodega();
                infoVinosImportados = IAPIBodega.getNovedades(bodegaElegida);
            }
            catch (Exception ex)
            {
                // En caso de que ocurra un error al obtener la información de la API externa
                MessageBox.Show($"El sistema externo de bodegas no dio respuesta. Error: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
       
        public void setOrNewVinos(PantallaAtualizacionVino pantallaAtualizacionVino)
        {
            vinos.Clear();
            nombreVinos.Clear();
            añadaVinos.Clear();
            precioARSVinos.Clear();
            maridajeVinos.Clear();
            varietalVinos.Clear();
            tipoUvaVinos.Clear();
            notaDeCataVinos.Clear();
            int i = 0;
            //var vinosBD = getVinosSinBD(); //Analisis
            var vinosBD = vinoRepositorio.ObtenerVinos(bodegaElegida, maridajeRepositorio,
                varietalRepositorio, tipoUvaRepositorio);
            foreach (var infoVinoImportado in infoVinosImportados)
            {
                var vinoBuscado = determinarVinoAActualizar(infoVinoImportado, vinosBD);
                if (vinoBuscado != null && (vinoBuscado.getPrecioARS()!=infoVinoImportado.precioARS ||
                    vinoBuscado.getNotaDeCataBodega()!=infoVinoImportado.notaDeCataBodega))
                {
                    actualizarVinoExistente(infoVinoImportado, vinoBuscado);
                    vinoRepositorio.ActualizarVino(vinoBuscado);
                    nombreVinos.Add(vinoBuscado.getNombre());
                    añadaVinos.Add(vinoBuscado.getAñada());
                    precioARSVinos.Add(vinoBuscado.getPrecioARS());
                    
                    maridajeVinos.Add(vinoBuscado.getMaridaje().getNombre());
                    varietalVinos.Add(vinoBuscado.getVarietal().getPorcentajeComposicion());
                    tipoUvaVinos.Add(vinoBuscado.getVarietal().getTipoUva().getNombre());

                    notaDeCataVinos.Add(vinoBuscado.getNotaDeCataBodega());

                    vinos.Add(vinoBuscado);
                    i++;
                }
                if(vinoBuscado==null)
                {
                    vinos.Add(crearVino(infoVinoImportado));
                    nombreVinos.Add(vinos[i].getNombre());
                    añadaVinos.Add(vinos[i].getAñada());
                    precioARSVinos.Add(vinos[i].getPrecioARS());

                    maridajeVinos.Add(vinos[i].getMaridaje().getNombre());
                    varietalVinos.Add(vinos[i].getVarietal().getPorcentajeComposicion());
                    tipoUvaVinos.Add(vinos[i].getVarietal().getTipoUva().getNombre());

                    notaDeCataVinos.Add(vinos[i].getNotaDeCataBodega());
                    i++;
                }
                
            }
            bodegaElegida.setFechaUltimaActualizacion(DateTime.Now);
            pantallaAtualizacionVino.mostrarResumenVinosImportados(vinos);
        }
        public Vino determinarVinoAActualizar(VinoActualizacion infoVinoImportado, List<Vino> vinosBD)
        {
            return bodegaElegida.esTuVino(infoVinoImportado, vinosBD);
        }
        public void actualizarVinoExistente(VinoActualizacion vinoActualizacion, Vino vinoAActualizar) 
        {
            bodegaElegida.setDatosVino(vinoActualizacion, vinoAActualizar);
        }
        public Vino crearVino(VinoActualizacion vinoCrear) {
            var meridaje = buscarMaridaje(vinoCrear.maridaje);
            var tipoUva = buscarTipoUva(vinoCrear.varietal.tipoUva.nombre);
            Vino vino = new Vino(meridaje,tipoUva,vinoCrear.nombre,
                vinoCrear.añada,vinoCrear.notaDeCataBodega,
                vinoCrear.precioARS,vinoCrear.varietal.descripcion,
                vinoCrear.varietal.porcentajeComposicion, bodegaElegida);
            vinoRepositorio.RegistrarVino(vino, varietalRepositorio);
            return vino;
        }
        public Maridaje buscarMaridaje(string nombre) {
            //var maridajesBD = getMaridajesSinBD(); //Analisis
            var maridajesBD = maridajeRepositorio.ObtenerMaridajes();
            foreach (var maridajeBD in maridajesBD) {
                if (maridajeBD.sosMaridaje(nombre)) return maridajeBD;
            }
            return null;
        }
        public TipoUva buscarTipoUva(string nombre){
            //var tipoUvasBD = getTipoUvasSinBD(); //Analisis
            var tipoUvasBD = tipoUvaRepositorio.ObtenerTiposUva();
            foreach (var tipoUvaBD in tipoUvasBD)
            {
                if (tipoUvaBD.sosTipoUva(nombre)) return tipoUvaBD;
            }
            return null;
        }
        public void buscarSeguidoresBodega(){
            //var enofilosBD = GetEnofilosSinBD();//Analisis
            var enofilosBD = siguiendoRepositorio.ObtenerEnofilosSeguidores(bodegaElegida,enofilosRepositorio,
                usuarioRepositorio);
            usuarios.Clear();
            foreach (var enofilo in enofilosBD)
            {

                if (enofilo.SeguisABodega(bodegaElegida)) {
                    //hace un atributo de array para los usuarios
                    enofilosSeguidoresDeBodega.Add(enofilo);
                    usuarios.Add(enofilo.getUsuario().getNombre());        
                }      
            }
        }
        //analisis
        /*public void notificar()
        {
            var INotificacionPush = new InterfazNotificacionPush();
            INotificacionPush.notificarNovedadVinoBodega(enofilosSeguidoresDeBodega);
            enofilosSeguidoresDeBodega.Clear();

        }*/
        public void suscribir(IObserverNotificacionVinosBodega observador)
        {
            elementos.Add(observador);
        }
        public void notificar()
        { 
            foreach (var usuario in usuarios)
            {
                elementos[0].notificarNovedadVinosBodega(bodegaElegida.getNombre(), nombreVinos, añadaVinos,precioARSVinos, maridajeVinos, 
                    varietalVinos, tipoUvaVinos,notaDeCataVinos,usuario);
            }

        }
        public void quitar(IObserverNotificacionVinosBodega observador)
        {
            throw new NotImplementedException();
        }
        public void finCU() 
        {
            bodegas.Clear();
            MessageBox.Show("C.U 5 - Grupo Reyes del Singleton", "Fin de Caso de Uso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        
    }
}
