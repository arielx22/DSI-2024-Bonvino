using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Pesistecia.Repositorio
{
    public class MaridajeRepositorio
    {
        public Maridaje ObtenerMaridaje(string nombre)
        {
            var maridaje = new Maridaje();
            var sentenciaSql = $"SELECT * FROM maridaje WHERE Nombre like '{nombre}'";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                maridaje.nombre = fila["Nombre"].ToString();
                if (!string.IsNullOrEmpty(fila["Descripcion"].ToString()))
                    maridaje.descripcion = fila["Descripcion"].ToString();
            }
            return maridaje;
        }
        public List<Maridaje> ObtenerMaridajes()
        {
            var maridajes = new List<Maridaje>();
            var sentenciaSql = "SELECT * FROM Maridaje";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var maridaje = new Maridaje();
                maridaje.nombre = fila["nombre"].ToString();
                if(!string.IsNullOrEmpty(fila["descripcion"].ToString()))
                    maridaje.descripcion = fila["descripcion"].ToString();
                maridajes.Add(maridaje);
            }
            return maridajes;
        }
    }
}
