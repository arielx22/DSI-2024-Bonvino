using Bonvino.Clases;
using Bonvino.Pesistecia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Persistencia.Repositorio
{
    public class SiguiendoRepositorio
    {
        public List<Siguiendo> ObtenerEnofilos(string bodega)
        {
            List<Siguiendo> siguiendos = new List<Siguiendo>();
            var sentenciaSql = $"SELECT * FROM enofilo WHERE '{bodega}' like BodegaNombre";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var siguiendo = new Siguiendo();
                
 
                /*
                usuario.nombre = fila["Nombre"].ToString();
                usuario.contraseña = fila["Contraseña"].ToString();
                usuario.premium = fila["Premium"].ToString() == "0" ? false : true;
                enofilos.Add(usuario);*/
            }
            return siguiendos;
        }
    }
}
