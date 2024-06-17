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

            if (bodegaElegida.nombre == "a")
            {
                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Vino Dulce Cosecha Tardía",
                    añada = 2020,
                    precioARS = 20000,
                    notaDeCataBodega = "Aromas a frutas maduras y miel, con un toque de vainilla.",
                });
                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Vino Malbec Reserva",
                    añada = 2015,
                    precioARS = 27000,
                    notaDeCataBodega = "Notas de ciruela, mora y un ligero toque de roble.",
                });
                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Vino...",
                    añada = 2023,
                    precioARS = 12000,
                    notaDeCataBodega = "Frutos rojos frescos y un matiz especiado.",
                });
            }
            if (bodegaElegida.nombre=="b")
            {
                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Vino Cabernet Sauvignon",
                    añada = 2022,
                    precioARS = 20000,
                    notaDeCataBodega = "Aromas intensos a grosellas y cedro, con taninos suaves y persistentes.",
                });
                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Vino Garnacha",
                    añada = 2021,
                    precioARS = 8000,
                    notaDeCataBodega = "Notas de frutos rojos maduros y especias, con un final suave y persistente.",
                });
                actualizaciones.Add(new VinoActualizacion
                {
                    nombre = "Vino Reserva Especial 2020",
                    añada = 2020,
                    precioARS = 12000,
                    notaDeCataBodega = "Notas de cereza, violeta y un toque de regaliz, con un final fresco y elegante.",
                });
            }
            
            return actualizaciones;
        }

    }
}
