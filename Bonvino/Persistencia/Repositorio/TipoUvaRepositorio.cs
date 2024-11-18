using Bonvino.Clases;
using System;
using System.Collections.Generic;
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
            var sentenciaSql = $"SELECT * FROM tipouva WHERE Nombre = {nombre}";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                tipoUva.nombre = fila["Nombre"].ToString();
                if (!string.IsNullOrEmpty(fila["Descripcion"].ToString())) 
                    tipoUva.descripcion = fila["Descripcion"].ToString();
            }
            return tipoUva;
        }
    }
}
