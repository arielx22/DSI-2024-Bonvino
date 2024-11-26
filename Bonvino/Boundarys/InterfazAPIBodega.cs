using Bonvino.Clases.Actualizacion;
using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Boundarys
{
    public class InterfazAPIBodega
    {
        public InterfazAPIBodega() { }
        
        public List<VinoActualizacion> getNovedades(Bodega bodegaElegida)
        {
            List<VinoActualizacion> actualizaciones = new List<VinoActualizacion>();

            if (bodegaElegida.nombre == "Bodega Catena Zapata")
            {

                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Catena Pinot Noir",
                    añada = 2020,
                    precioARS = 20000,
                    maridaje = "Vinos y Sabores",
                    notaDeCataBodega = "Aromas seductores de cerezas frescas, " +
                    "fresas maduras y delicadas notas florales",
                    varietal = new VarietalActualizacion
                    {
                        porcentajeComposicion = 0.60f,
                        descripcion = "Catena Pinot Noir",
                        tipoUva = new TipoUvaActualizacion()
                        {
                            nombre = "Pinot Noir"
                        }
                    }
                });

                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Catena Malbec",
                    añada = 2015,
                    precioARS = 27000,
                    maridaje = "Maridaje de Excelencia",
                    notaDeCataBodega = "Notas de ciruela, mora y un ligero " +
                    "toque de roble.",
                    varietal = new VarietalActualizacion
                    {
                        porcentajeComposicion = 0.67f,
                        descripcion = "Catena Malbec",
                        tipoUva = new TipoUvaActualizacion()
                        {
                            nombre = "Malbec"
                        }
                    }
                });

                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Cantena Chardonnay",
                    añada = 2023,
                    precioARS = 12000,
                    maridaje = "Armonías en la Mesa",
                    notaDeCataBodega = "Frutos frescos y un matiz especiado.",
                    varietal = new VarietalActualizacion
                    {
                        porcentajeComposicion = 0.65f,
                        descripcion = "Cantena Chardonnay",
                        tipoUva = new TipoUvaActualizacion()
                        {
                            nombre = "Chardonnay"
                        }
                    }
                });
            }
            if (bodegaElegida.nombre== "Bodega Norton")
            {
                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Norton Cabernet Sauvignon",
                    añada = 2022,
                    precioARS = 20000,
                    maridaje = "Maridaje de Excelencia",
                    notaDeCataBodega = "Aromas intensos a grosellas y cedro, con " +
                    "taninos suaves y persistentes.",
                    varietal = new VarietalActualizacion
                    {
                        descripcion = "Maridaje de Excelencia",
                        porcentajeComposicion = 0.70f,
                        tipoUva = new TipoUvaActualizacion()
                        {
                            nombre = "Cabernet Sauvignon"
                        }
                    }
                });

                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Norton Garnacha",
                    añada = 2021,
                    precioARS = 8000,
                    maridaje = "Vinos y Sabores",
                    notaDeCataBodega = "Notas de frutos rojos maduros y especias, con " +
                    "un final suave y persistente toque de roble.",
                    varietal = new VarietalActualizacion
                    {
                        descripcion = "Vinos y Sabores",
                        porcentajeComposicion = 0.66f,
                        tipoUva = new TipoUvaActualizacion()
                        {
                            nombre = "Garnacha"
                        }
                    }
                });

                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Norton Reserva",
                    añada = 2020,
                    precioARS = 12000,
                    maridaje = "Armonías en la Mesa",
                    notaDeCataBodega = "Notas de cereza, violeta y un toque de regaliz, " +
                    "con un final fresco y elegante.",
                    varietal = new VarietalActualizacion
                    {
                        descripcion = "Norton Reserva",
                        porcentajeComposicion = 0.60f,
                        tipoUva = new TipoUvaActualizacion()
                        {
                            nombre = "Malbec"
                        }
                    }
                });           
            }
            if (bodegaElegida.nombre == "Weingut Dr. Loosen")
            {
                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Norton Cabernet Sauvignon",
                    añada = 2020,
                    precioARS = 20000,
                    maridaje = "Maridaje de Excelencia",
                    notaDeCataBodega = "Aromas intensos a grosellas y cedro, con " +
                    "taninos suaves y persistentes.",
                    varietal = new VarietalActualizacion
                    {
                        descripcion = "Maridaje de Excelencia",
                        porcentajeComposicion = 0.70f,
                        tipoUva = new TipoUvaActualizacion()
                        {
                            nombre = "Cabernet Sauvignon"
                        }
                    }
                });   
            }

            return actualizaciones;
        }

    }
}
