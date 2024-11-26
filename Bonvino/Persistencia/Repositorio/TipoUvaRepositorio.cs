using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Pesistecia.Repositorio
{
    public class TipoUvaRepositorio
    {
        public TipoUva ObtenerTipoUva(string nombre)
        {
            var tipoUva = new TipoUva();
            var sentenciaSql = $"SELECT * FROM TipoUva WHERE nombre = '{nombre}'";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                tipoUva.setNombre(fila["nombre"].ToString());
                if (!string.IsNullOrEmpty(fila["descripcion"].ToString())) 
                    tipoUva.setDescripcion(fila["descripcion"].ToString());
            }
            return tipoUva;
        }
        public List<TipoUva> ObtenerTiposUva()
        {
            var tiposUva = new List<TipoUva>();
            var sentenciaSql = "SELECT * FROM TipoUva";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var tipoUva = new TipoUva();
                tipoUva.setNombre(fila["nombre"].ToString());
                if (!string.IsNullOrEmpty(fila["descripcion"].ToString()))
                    tipoUva.setDescripcion(fila["descripcion"].ToString());
                tiposUva.Add(tipoUva);
            }
            return tiposUva;
        }

    }
}
