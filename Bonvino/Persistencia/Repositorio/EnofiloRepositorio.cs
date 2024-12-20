﻿using Bonvino.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonvino.Pesistecia.Repositorio
{
    public class EnofiloRepositorio
    {
        public Enofilo ObtenerEnofilo(int id, Siguiendo siguiendo,UsuarioRepositorio usuarioRepositorio)
        {
            var enofilo = new Enofilo();
            var sentenciaSql = $"SELECT * FROM enofilo WHERE Id = {id}";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                enofilo.setNombre(fila["Nombre"].ToString());
                enofilo.setApellido(fila["Apellido"].ToString());
                var siguiendos = new List<Siguiendo>();
                siguiendos.Add(siguiendo);
                enofilo.setSiguiendo(siguiendos);
                enofilo.setUsuario(usuarioRepositorio.ObtenerUsuario(fila["nombreUsuario"].ToString()));
            }
            return enofilo;
        }
    }
}
