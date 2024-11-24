using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Pesistecia.Repositorio
{
    public class BodegaRepositorio
    {
        public List<Bodega> ObtenerBodegas()
        {
            List<Bodega> bodegas = new List<Bodega>();
            var sentenciaSql = "SELECT * FROM bodega";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var bodega = new Bodega();
                bodega.nombre = fila["nombre"].ToString();
                if (!string.IsNullOrEmpty(fila["historia"].ToString())) bodega.historia = fila["historia"].ToString();
                if (!string.IsNullOrEmpty(fila["descripcion"].ToString())) bodega.descripcion = fila["descripcion"].ToString();
                bodega.periodoActualizacion = Convert.ToInt32(fila["periodoActualizacion"]);
                bodega.fechaUltimaActualizacion = Convert.ToDateTime(fila["fechaUltimaActualizacion"]);
                if (fila["CoordenadasUbicacionEnX"] != DBNull.Value && fila["CoordenadasUbicacionEnY"] != DBNull.Value)
                {
                    // Convertir las coordenadas en float y agregarlas a la lista
                    float coordenadaX = Convert.ToSingle(fila["CoordenadasUbicacionEnX"]);
                    float coordenadaY = Convert.ToSingle(fila["CoordenadasUbicacionEnY"]);

                    // Crear la lista de coordenadas y asignarla a la propiedad de la bodega
                    bodega.coordenadasUbicacion = new List<float> { coordenadaX, coordenadaY };
                }
                bodegas.Add(bodega);
            }
            return bodegas;
        }
    }
}
