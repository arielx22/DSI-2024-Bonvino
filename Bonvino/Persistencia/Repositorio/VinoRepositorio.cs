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
 
        public void RegistrarVino(Vino vino, VarietalRepositorio varietalRepositorio)
        {
            varietalRepositorio.RegistrarVarietal(vino.varietal);
            var sentenciaSql = $"INSERT INTO Vino(añada, nombre, fechaActualizacion, precioARS, varietalId, maridajeNombre, bodegaNombre,notaDeCataBodega)" +
                $"VALUES({vino.añada}, '{vino.nombre}', '{vino.fechaActualizacion.ToString("dd-MM-yyyy")}', " +
                $"{vino.precioARS}, {varietalRepositorio.ObtenerVarietalId()}, '{vino.maridaje.nombre}'," +
                $" '{vino.bodega.nombre}', '{vino.notaDeCataBodega}')";
            DBHelper.GetDBHelper().EjecutarSQL(sentenciaSql);
        }

        public void ActualizarVino(Vino vino, VarietalRepositorio varietalRepositorio)
        {
            //varietalId={varietalRepositorio.ObtenerVarietalId()} esta mal esto esta siempre actualizando siempre con el ultimo varietal de la BD
            var sentenciaSql = $"UPDATE Vino SET fechaActualizacion='{vino.fechaActualizacion.ToString("dd-MM-yyyy")}'," +
                $"precioARS='{vino.precioARS}', varietalId={varietalRepositorio.ObtenerVarietalId()}, " +
                $"maridajeNombre ='{vino.maridaje.nombre}', bodegaNombre= '{vino.bodega.nombre}', notaDeCataBodega='{vino.notaDeCataBodega}'" +
                $"WHERE nombre ='{vino.nombre}' and añada={vino.añada}";
            DBHelper.GetDBHelper().EjecutarSQL(sentenciaSql);
        }
    }
}
