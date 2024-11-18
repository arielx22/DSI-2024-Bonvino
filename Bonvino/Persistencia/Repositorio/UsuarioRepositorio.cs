using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Pesistecia.Repositorio
{
    public class UsuarioRepositorio
    {
        public Usuario ObtenerUsuario(int id)
        {
            var usuario = new Usuario();
            var sentenciaSql = $"SELECT * FROM usuario WHERE Id = {id}";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                usuario.nombre = fila["Nombre"].ToString();
                usuario.contraseña = fila["Contraseña"].ToString();
                usuario.premium = fila["Premium"].ToString() == "0" ? false : true;
            }
            return usuario;
        }
    }
}
