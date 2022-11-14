using SISTEMADEINGRESO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISTEMADEINGRESO.Procedures
{
    public class CRUD : Controller
    {
        static string cadena = Conexion.Sql();
        public static List<Personas> ListaPersonas()
        {
            List<Personas> Per = new List<Personas>();

            string Query = "SELECT * FROM Personas";


            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(Query, cn);

                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Personas oPersonas = new Personas();

                        oPersonas.Documento = Convert.ToInt32(reader["Documento"]);
                        oPersonas.Nombres = reader["Nombres"].ToString();
                        oPersonas.Apellido1 = reader["Apellido1"].ToString();
                        oPersonas.Apellido2 = reader["Apellido2"].ToString();
                        oPersonas.Ciudad = reader["Ciudad"].ToString();
                        oPersonas.Departamento = reader["Departamento"].ToString();
                        oPersonas.Direccion = reader["Direccion"].ToString();
                        oPersonas.Celular = reader["Celular"].ToString();
                        oPersonas.Email = reader["Email"].ToString();

                        Per.Add(oPersonas);
                    }
                    reader.Close();
                    cn.Close();
                }
                catch (Exception Ex)
                {
                    throw new Exception("Hay un error en el query" + Ex.Message);
                }
            }
            return Per;
        }
    }
}