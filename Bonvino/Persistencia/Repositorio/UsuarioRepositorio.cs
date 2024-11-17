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
        public List<Usuario> ObtenerUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            var sentenciaSql = "SELECT * FROM Usuario";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var usuario = new Usuario();
                usuario.nombre = fila["Nombre"].ToString();
                usuario.contraseña = fila["Contraseña"].ToString();
                usuario.premium = fila["Premium"].ToString() == "0" ? false : true;
                usuarios.Add(usuario);
            }
            return usuarios;
        }
    }
}
