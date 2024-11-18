using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Pesistecia.Repositorio
{
    internal class VinoRepositorio
    {
        public List<Vino> ObtenerVinos(Bodega bodega,MaridajeRepositorio maridajeRepositorio,
            VarietalRepositorio varietalRepositorio,TipoUvaRepositorio tipoUvaRepositorio)
        {
            List<Vino> vinos = new List<Vino>();
            var sentenciaSql = $"SELECT * FROM vino " +
                $"WHERE '{bodega.nombre}' LIKE bodegaNombre";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var vino = new Vino();
                vino.añada = Convert.ToInt32(fila["Anada"].ToString());
                vino.nombre = fila["Nombre"].ToString();
                if (!string.IsNullOrEmpty(fila["FechaActualizacion"].ToString())) 
                    vino.fechaActualizacion = Convert.ToDateTime(fila["FechaActualizacion"].ToString());
                if (fila["ImagenEtiqueta"] != DBNull.Value)
                {
                    // Asignar el valor de la base de datos al byte[]
                    vino.imagenEtiqueta = (byte[])fila["ImagenEtiqueta"];
                }
                if (!string.IsNullOrEmpty(fila["NotaDeCataBodega"].ToString())) 
                    vino.notaDeCataBodega = fila["NotaDeCataBodega"].ToString();
                vino.precioARS = Convert.ToSingle(fila["NotaDeCataBodega"].ToString());
                var varietal = varietalRepositorio.ObtenerVarietal(
                    Convert.ToInt32(fila["VarietalId"].ToString()),tipoUvaRepositorio);
                vino.varietal = varietal;
                var maridaje = maridajeRepositorio.ObtenerMaridaje(fila["MaridajeNombre"].ToString());
                vino.maridaje = maridaje;
                vino.bodega = bodega;
                vinos.Add(vino);
            }
            return vinos;
        }
    }
}
