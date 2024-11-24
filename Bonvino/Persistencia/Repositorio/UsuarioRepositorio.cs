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
        public Usuario ObtenerUsuario(string nombre)
        {
            var usuario = new Usuario();
            var sentenciaSql = $"SELECT * FROM Usuario WHERE nombre = '{nombre}'";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                usuario.nombre = nombre;
                usuario.contraseña = fila["contraseña"].ToString();
                usuario.premium = fila["premium"].ToString() == "0" ? false : true;
            }
            return usuario;
        }
    }
}
