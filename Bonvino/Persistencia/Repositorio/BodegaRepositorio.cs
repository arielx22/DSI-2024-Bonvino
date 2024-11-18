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
                bodega.nombre = fila["Nombre"].ToString();
                if (!string.IsNullOrEmpty(fila["Historia"].ToString())) bodega.historia = fila["Historia"].ToString();
                if (!string.IsNullOrEmpty(fila["Descripcion"].ToString())) bodega.descripcion = fila["Descripcion"].ToString();
                bodega.periodoActualizacion = Convert.ToInt32(fila["PeriodoActualizacion"].ToString());
                bodega.fechaUltimaActualizacion = Convert.ToDateTime(fila["FechaUltimaActualizacion"].ToString());
                if (!string.IsNullOrEmpty(fila["CoordenadasUbicacion"].ToString()))
                {
                    // Obtener el string de las coordenadas
                    string coordenadasStr = fila["CoordenadasUbicacion"].ToString();

                    // Separar la cadena por comas y convertir cada valor a int
                    List<int> coordenadas = coordenadasStr
                        .Split(',') // Usamos la coma como delimitador
                        .Select(s => int.Parse(s.Trim())) // Convertir cada fragmento a entero
                        .ToList();

                    // Asignar la lista al objeto 'bodega'
                    bodega.coordenadasUbicacion = coordenadas;
                }
                bodegas.Add(bodega);
            }
            return bodegas;
        }
    }
}
