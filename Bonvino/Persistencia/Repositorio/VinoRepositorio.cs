using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
                $"WHERE '{bodega.getNombre()}' LIKE bodegaNombre";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var vino = new Vino();
                vino.setAñada(Convert.ToInt32(fila["añada"]));
                vino.setNombre(fila["nombre"].ToString());
                if (!string.IsNullOrEmpty(fila["fechaActualizacion"].ToString())) 
                    vino.setFechaActualizacion(Convert.ToDateTime(fila["fechaActualizacion"].ToString()));
                if (fila["ImagenEtiqueta"] != DBNull.Value)
                {
                    // Asignar el valor de la base de datos al byte[]
                    vino.setImagenEtiqueta((byte[])fila["imagenEtiqueta"]);
                }
                if (!string.IsNullOrEmpty(fila["notaDeCataBodega"].ToString())) 
                    vino.setNotaDeCataBodega(fila["notaDeCataBodega"].ToString());
                vino.setPrecioARS(Convert.ToSingle(fila["precioARS"]));
                vino.setVarietal(varietalRepositorio.ObtenerVarietal(
                    Convert.ToInt32(fila["varietalId"]), tipoUvaRepositorio));
                vino.setMaridaje(maridajeRepositorio.ObtenerMaridaje(fila["maridajeNombre"].ToString()));
                vino.setBodega(bodega);
                vinos.Add(vino);
            }
            return vinos;
        }
 
        public void RegistrarVino(Vino vino, VarietalRepositorio varietalRepositorio)
        {
            varietalRepositorio.RegistrarVarietal(vino.getVarietal());
            var sentenciaSql = $"INSERT INTO Vino(añada, nombre, fechaActualizacion, precioARS, varietalId, maridajeNombre, bodegaNombre,notaDeCataBodega)" +
                $"VALUES({vino.getAñada()}, '{vino.getNombre()}', '{vino.getFechaActualizacion().ToString("dd-MM-yyyy")}', " +
                $"{vino.getPrecioARS().ToString("0.##", CultureInfo.InvariantCulture)}, {varietalRepositorio.ObtenerVarietalId()}, '{vino.getMaridaje().getNombre()}'," +
                $" '{vino.getBodega().getNombre()}', '{vino.getNotaDeCataBodega()}')";
            DBHelper.GetDBHelper().EjecutarSQL(sentenciaSql);
        }

        public void ActualizarVino(Vino vino)
        {
            var sentenciaSql = $"UPDATE Vino SET fechaActualizacion='{vino.getFechaActualizacion().ToString("dd-MM-yyyy")}'," +
                $"precioARS='{vino.getPrecioARS().ToString("0.##", CultureInfo.InvariantCulture)}', notaDeCataBodega='{vino.getNotaDeCataBodega()}'" +
                $"WHERE nombre ='{vino.getNombre()}' and añada={vino.getAñada()}";
            DBHelper.GetDBHelper().EjecutarSQL(sentenciaSql);
        }
    }
}
