using Bonvino.Clases;
using Bonvino.Clases.Actualizacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
                varietal.setDescripcion(fila["descripcion"].ToString());
                varietal.setPorcentajeComposicion(Convert.ToSingle(fila["porcentajeComposicion"]));
                varietal.setTipoUva(tipoUvaRepositorio.ObtenerTipoUva(fila["tipoUvaNombre"].ToString()));
            }
            return varietal;
        }
        public void RegistrarVarietal(Varietal varietal)
        {
            var sentenciaSql = $"INSERT INTO Varietal(descripcion, porcentajeComposicion, tipoUvaNombre) " +
                $"VALUES('{varietal.getDescripcion()}', {varietal.getPorcentajeComposicion().ToString("0.##", CultureInfo.InvariantCulture)}, '{varietal.getTipoUva().getNombre()}')";
            DBHelper.GetDBHelper().EjecutarSQL(sentenciaSql);
        }
        public int ObtenerVarietalId()
        {
            // Obtener el máximo ID actual
            var sentenciaSql = "SELECT MAX(id) as id FROM Varietal";
            int maxId = -1;
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                maxId = Convert.ToInt32(fila["id"]);
            }
            return maxId;
        }
    }
}
