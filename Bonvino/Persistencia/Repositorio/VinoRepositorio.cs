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
                vino.añada = Convert.ToInt32(fila["añada"]);
                vino.nombre = fila["nombre"].ToString();
                if (!string.IsNullOrEmpty(fila["fechaActualizacion"].ToString())) 
                    vino.fechaActualizacion = Convert.ToDateTime(fila["fechaActualizacion"].ToString());
                if (fila["ImagenEtiqueta"] != DBNull.Value)
                {
                    // Asignar el valor de la base de datos al byte[]
                    vino.imagenEtiqueta = (byte[])fila["imagenEtiqueta"];
                }
                if (!string.IsNullOrEmpty(fila["notaDeCataBodega"].ToString())) 
                    vino.notaDeCataBodega = fila["notaDeCataBodega"].ToString();
                vino.precioARS = Convert.ToSingle(fila["precioARS"]);
                vino.varietal = varietalRepositorio.ObtenerVarietal(
                    Convert.ToInt32(fila["varietalId"]), tipoUvaRepositorio);
                vino.maridaje = maridajeRepositorio.ObtenerMaridaje(fila["maridajeNombre"].ToString());
                vino.bodega = bodega;
                vinos.Add(vino);
            }
            return vinos;
        }
    }
}
