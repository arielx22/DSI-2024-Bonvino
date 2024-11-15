﻿using Bonvino.Boundarys;
using Bonvino.Clases;
using Bonvino.Clases.Actualizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonvino.Controladores
{
    public class GestorActualizacionVino
    {
        private List<Bodega> bodegas;
        private Bodega bodegaElegida;
        private List<VinoActualizacion> infoVinosImportados;
        private List<Enofilo> enofilosSeguidoresDeBodega;
        
        public GestorActualizacionVino() {
            bodegas = new List<Bodega>();
            enofilosSeguidoresDeBodega = new List<Enofilo>();
        }
        public void opImportarActualizacionVino(PantallaAtualizacionVino pantallaAtualizacionVino) {
            buscarBodegaActualizacionDisponible();
            pantallaAtualizacionVino.mostrarBodegasActualizables(bodegas);
        }
        public void buscarBodegaActualizacionDisponible()
        {
            //Para que no se repitan las bodegas en la lista, 
            //cuando se hace click en el boton importar.
            bodegas.Clear();
            var bodegasBD = getBodegasSinBD();
            DateTime fechaActual = DateTime.Now;
            int i = 0;
            foreach (var bodega in bodegasBD)
            {
                if (bodega.esActualizable(fechaActual))
                {
                    bodegas.Add(bodega);
                    bodegas[i].nombre = bodega.nombre;
                    i++;
                }
            }
        }
        public void seleccionBodega(Bodega bodegaElegida, PantallaAtualizacionVino pantallaAtualizacionVino)
        {
            this.bodegaElegida = bodegaElegida;
            buscarActualizaciones();
            setOrNewVinos(pantallaAtualizacionVino);
            buscarSeguidoresBodega();
            notificar();
            finCU();
        }
        public void buscarActualizaciones()
        {
            var IAPIBodega = new InterfazAPIBodega();
            infoVinosImportados = IAPIBodega.getNovedades(bodegaElegida);
        }
        
       
        public void setOrNewVinos(PantallaAtualizacionVino pantallaAtualizacionVino)
        {
            var vinosBD = getVinosSinBD();
            var vinosResumenTipoVino = new List<Vino>();
            foreach (var infoVinoImportado in infoVinosImportados)
            {
                var vinoBuscado = determinarVinoAActualizar(infoVinoImportado, vinosBD);
                if (vinoBuscado != null)
                {
                    actualizarVinoExistente(infoVinoImportado, vinoBuscado);
                    vinosResumenTipoVino.Add(vinoBuscado);
                }
                else
                {
                    Vino vinoCreado = crearVino(infoVinoImportado);
                    vinosResumenTipoVino.Add(vinoCreado);
                }
            }
            bodegaElegida.fechaUltimaActualizacion = DateTime.Now;
            pantallaAtualizacionVino.mostrarResumenVinosImportados(vinosResumenTipoVino);
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
                vinoCrear.varietal.porcentajeComposicion);
            return vino;
        }
        public Maridaje buscarMaridaje(string nombre) {
            var maridajesBD = getMaridajesSinBD();
            foreach (var maridajeBD in maridajesBD) {
                if (maridajeBD.sosMaridaje(nombre)) return maridajeBD;
            }
            return null;
        }
        public TipoUva buscarTipoUva(string nombre){
            var tipoUvasBD = getTipoUvasSinBD();
            foreach (var tipoUvaBD in tipoUvasBD)
            {
                if (tipoUvaBD.sosTipoUva(nombre)) return tipoUvaBD;
            }
            return null;
        }
        public void buscarSeguidoresBodega(){
            var enofilosBD = GetEnofilosSinBD();
            int i = 0;
            foreach (var enofilo in enofilosBD)
            {
                if (enofilo.seguisABodega(bodegaElegida)) {

                    enofilosSeguidoresDeBodega.Add(enofilo);
                    enofilosSeguidoresDeBodega[i].usuario.nombre = enofilo.usuario.nombre;
                    i++;
                }      
            }
        }
        public void notificar()
        {
            var INotificacionPush = new InterfazNotificacionPush();

            INotificacionPush.notificarNovedadVinoBodega(enofilosSeguidoresDeBodega);
            enofilosSeguidoresDeBodega.Clear();

        }
        public void finCU() 
        {
            MessageBox.Show("C.U 5 - Grupo Reyes del Singleton", "Fin de Caso de Uso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Hardcode
        public List<Bodega> getBodegasSinBD()
        {
            // Crear una lista de Bodegas
            List<Bodega> bodegasBD = new List<Bodega>();

            var bodega1 = new Bodega();
            bodega1.nombre = "Bodega Catena Zapata";
            bodega1.periodoActualizacion = 1;
            bodega1.fechaUltimaActualizacion = DateTime.Now.AddMonths(-2);
            bodegasBD.Add(bodega1);

            var bodega2 = new Bodega();
            bodega2.nombre = "Bodega Norton";
            bodega2.periodoActualizacion = 3;
            bodega2.fechaUltimaActualizacion = DateTime.Now.AddMonths(-4);
            bodegasBD.Add(bodega2);

            var bodega3 = new Bodega();
            bodega3.nombre = "Bodega Trapiche";
            bodega3.periodoActualizacion = 4;
            bodega3.fechaUltimaActualizacion = DateTime.Now.AddMonths(-1);
            bodegasBD.Add(bodega3);

            return bodegasBD;
        }
        public List<Vino> getVinosSinBD()
        {
            List<Vino> vinosBD = new List<Vino>();
            //Vino1
            vinosBD.Add(new Vino()
            {
                nombre = "Catena Malbec",
                añada = 2015,
                precioARS = 25000,
                maridaje = new Maridaje()
                {
                    descripcion = "asdasd",
                    nombre = "Maridaje de Excelencia"
                },
                varietal = new Varietal()
                {
                    porcentajeComposicion = 0.67,
                    tipoUva = new TipoUva()
                    {
                        nombre = "Malbec"
                    }
                }
            });
            //Vino2
            vinosBD.Add(new Vino()
            {
                nombre = "Catena Chardonnay",
                añada = 2019,
                precioARS = 17000,
                maridaje = new Maridaje()
                {
                    descripcion = "asdasd",
                    nombre = "Maridaje Maestro"
                },
                varietal = new Varietal()
                {
                    porcentajeComposicion = 0.65,
                    tipoUva = new TipoUva()
                    {
                        nombre = "Malbec"
                    }
                }
            });
            //Vino3
            vinosBD.Add(new Vino()
            {
                nombre = "Catena Cabernet",
                añada = 2000,
                precioARS = 15000,
                maridaje = new Maridaje()
                {
                    descripcion = "asdasd",
                    nombre = "Vinos y Sabores"
                },
                varietal = new Varietal()
                {
                    porcentajeComposicion = 0.65,
                    tipoUva = new TipoUva()
                    {
                        nombre = "Malbec"
                    }
                }
            });
            //Vino4
            vinosBD.Add(new Vino()
            {
                nombre = "Norton Cabernet Sauvignon",
                añada = 2022,
                precioARS = 18000,
                maridaje = new Maridaje()
                {
                    descripcion = "asdasd",
                    nombre = "Maridaje de Excelencia"
                },
                varietal = new Varietal()
                {
                    porcentajeComposicion = 0.70,
                    tipoUva = new TipoUva()
                    {
                        nombre = "Malbec"
                    }
                }
            });
            //Vino5
            vinosBD.Add(new Vino()
            {
                nombre = "Norton Reserva",
                añada = 2015,
                precioARS = 15000,
                maridaje = new Maridaje()
                {
                    descripcion = "asdasd",
                    nombre = "Maridaje Maestro"
                },
                varietal = new Varietal()
                {
                    porcentajeComposicion = 0.75,
                    tipoUva = new TipoUva()
                    {
                        nombre = "Malbec"
                    }
                }
            });
            //Vino6
            vinosBD.Add(new Vino()
            {
                nombre = "Norton Privada",
                añada = 2020,
                precioARS = 14000,
                maridaje = new Maridaje()
                {
                    descripcion = "asdasd",
                    nombre = "Vinos y Sabores"
                },
                varietal = new Varietal()
                {
                    porcentajeComposicion = 0.72,
                    tipoUva = new TipoUva()
                    {
                        nombre = "Malbec"
                    }
                }
            });
            return vinosBD;
        }
        public List<Maridaje> getMaridajesSinBD()
        {
            List<Maridaje> maridajesBD = new List<Maridaje>();
            var maridaje1 = new Maridaje();
            maridaje1.nombre = "Armonías en la Mesa";
            maridaje1.descripcion = "Descubre cómo combinar vinos y platos para crear " +
                "experiencias gastronómicas memorables.";
            maridajesBD.Add(maridaje1);

            var maridaje2 = new Maridaje();
            maridaje2.nombre = "Maridaje Maestro";
            maridaje2.descripcion = "Domina las técnicas y principios detrás del maridaje " +
                "de vinos y alimentos para potenciar sabores y texturas.";
            maridajesBD.Add(maridaje2);

            var maridaje3 = new Maridaje();
            maridaje3.nombre = "Vinos y Sabores";
            maridaje3.descripcion = "Sumérgete en la sinfonía de sabores al aprender a " +
                "seleccionar vinos que complementen y realcen cada bocado.";
            maridajesBD.Add(maridaje3);

            var maridaje4 = new Maridaje();
            maridaje4.nombre = "Maridaje de Excelencia";
            maridaje4.descripcion = "Explora cómo la elección adecuada de vinos puede " +
                "transformar cada comida en una experiencia culinaria excepcional.";
            maridajesBD.Add(maridaje4);

            return maridajesBD;
        }
        public List<TipoUva> getTipoUvasSinBD()
        {
            List<TipoUva> tipoUvasBD = new List<TipoUva>();

            var tipoUva1 = new TipoUva();
            tipoUva1.nombre = "Malbec";
            tipoUva1.descripcion = "Produce vinos tintos oscuros y jugosos con sabores a " +
                "ciruela, moras y chocolate, con taninos suaves y una acidez equilibrada.";
            tipoUvasBD.Add(tipoUva1);

            var tipoUva2 = new TipoUva();
            tipoUva2.nombre = "Chardonnay";
            tipoUva2.descripcion = "Uva blanca, produce vinos blancos secos, afrutados y con cuerpo" +
                " medio a completo. Los vinos de Chardonnay suelen tener sabores a manzana, pera y " +
                "piña, con notas de vainilla y tostado si han sido envejecidos en roble.";
            tipoUvasBD.Add(tipoUva2);

            var tipoUva3 = new TipoUva();
            tipoUva3.nombre = "Garnacha";
            tipoUva3.descripcion = "Tiene acidez moderada y taninos suaves y sedosos, lo que la " +
                "hace muy accesible y fácil de beber, especialmente cuando se elabora en un " +
                "estilo más frutal y fresco.";
            tipoUvasBD.Add(tipoUva3);

            var tipoUva4 = new TipoUva();
            tipoUva4.nombre = "Pinot Noir";
            tipoUva4.descripcion = "Produce vinos elegantes y complejos, con " +
                "aromas a frutas rojas como cerezas y frambuesas, " +
                "notas florales y terrosas. Es conocido por su cuerpo ligero a " +
                "medio, buena acidez y taninos suaves.";
            tipoUvasBD.Add(tipoUva4);

            var tipoUva5 = new TipoUva();
            tipoUva5.nombre = "Cabernet Sauvignon";
            tipoUva5.descripcion = "equeñas, redondas y de piel gruesa. Son conocidas por tener bayas" +
                " de color oscuro y alto contenido de azúcar y taninos.";
            tipoUvasBD.Add(tipoUva5);


            return tipoUvasBD;
        }
        public List<Enofilo> GetEnofilosSinBD()
        {
            List<Enofilo> enofilosBD = new List<Enofilo>();

            //Enofilo1
            enofilosBD.Add(new Enofilo
            {
                apellido = "Allende",
                nombre = "Facundo",
                siguiendo = new Siguiendo
                {
                    bodegaME = new Bodega
                    {
                        nombre = "Bodega Catena Zapata"
                    }
                },
                usuario = new Usuario
                {
                    nombre = "FacAllende"
                }
            });
            //Enofilo2
            enofilosBD.Add(new Enofilo
            {
                apellido = "Zarate",
                nombre = "Ignacio",
                siguiendo = new Siguiendo
                {
                    bodegaME = new Bodega
                    {
                        nombre = "Bodega Catena Zapata"
                    }
                },
                usuario = new Usuario
                {
                    nombre = "IgZarate"
                }
            });
            //Enofilo3
            enofilosBD.Add(new Enofilo
            {
                apellido = "Braschi",
                nombre = "Cesar",
                siguiendo = new Siguiendo
                {
                    bodegaME = new Bodega
                    {
                        nombre = "Bodega Norton"
                    }
                },
                usuario = new Usuario
                {
                    nombre = "CeBraschi"
                }
            });
            //Enofilo4
            enofilosBD.Add(new Enofilo
            {
                apellido = "Posadas",
                nombre = "Lucas",
                siguiendo = new Siguiendo
                {
                    bodegaME = new Bodega
                    {
                        nombre = "Bodega Norton"
                    }
                },
                usuario = new Usuario
                {
                    nombre = "LuPosadas"
                }
            });
            return enofilosBD;
        }
    }
}
