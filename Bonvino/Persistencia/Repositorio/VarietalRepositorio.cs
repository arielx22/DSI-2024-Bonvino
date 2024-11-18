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
                varietal.descripcion = fila["Descripcion"].ToString();
                varietal.tipoUva = tipoUvaRepositorio.ObtenerTipoUva(fila["tipouva_Nombre"].ToString());
                if (!string.IsNullOrEmpty(fila["NotaDeCataBodega"].ToString()))
                    varietal.porcentajeComposicion = Convert.ToDouble(fila["NotaDeCataBodega"].ToString());
            }
            return varietal;
        }
    }
}
