using Bonvino.Clases;
using Bonvino.Pesistecia;
using Bonvino.Pesistecia.Repositorio;
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
        public List<Enofilo> ObtenerEnofilosSeguidores(Bodega bodega, EnofiloRepositorio enofiloRepositorio,
            UsuarioRepositorio usuarioRepositorio)
        {
            List<Enofilo> enofilos = new List<Enofilo>();
            var sentenciaSql = $"SELECT * FROM Siguiendo WHERE bodegaNombre like '{bodega.nombre}' and " +
                $"fechaFin is null";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var siguiendo = new Siguiendo();
                siguiendo.bodegaME = bodega;
                var enofilo = enofiloRepositorio.ObtenerEnofilo(Convert.ToInt32(fila["id"].ToString()),
                    siguiendo, usuarioRepositorio);
                enofilos.Add(enofilo);
            }
            return enofilos;
        }
    }
}
