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
        public List<Enofilo> ObtenerEnofilos(string bodega)
        {
            List<Enofilo> enofilos = new List<Enofilo>();
            var sentenciaSql = "SELECT * FROM enofilo ";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                var enofilo = new Enofilo();
                enofilo.nombre = fila["Nombre"].ToString();
                /*
                usuario.nombre = fila["Nombre"].ToString();
                usuario.contraseña = fila["Contraseña"].ToString();
                usuario.premium = fila["Premium"].ToString() == "0" ? false : true;
                enofilos.Add(usuario);*/
            }
            return enofilos;
        }
    }
}
