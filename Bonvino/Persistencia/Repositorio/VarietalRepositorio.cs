using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Pesistecia.Repositorio
{
    public class VarietalRepositorio
    {
        public Varietal ObtenerVarietal(int id, TipoUvaRepositorio tipoUvaRepositorio)
        {
            var varietal = new Varietal();
            var sentenciaSql = $"SELECT * FROM varietal WHERE Id = {id}";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                varietal.descripcion = fila["descripcion"].ToString();
                varietal.porcentajeComposicion = Convert.ToSingle(fila["porcentajeComposicion"]);
                varietal.tipoUva = tipoUvaRepositorio.ObtenerTipoUva(fila["tipoUvaNombre"].ToString());
                

            }
            return varietal;
        }
    }
}
