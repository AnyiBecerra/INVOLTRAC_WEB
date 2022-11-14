using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISTEMADEINGRESO.Procedures
{
    public class Conexion : Controller
    {
        static string Server = "localhost";
        static string DB = "INVOLTRAC";
        private static readonly string conexion = $"Data Source={Server};Initial Catalog={DB};Integrated Security=True";
        public static string Sql()
        {
            return conexion;
        }
    }
}