using SISTEMADEINGRESO.Models;
using SISTEMADEINGRESO.Procedures;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISTEMADEINGRESO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Personas> ListPersonas = ListaPersonas();
            return View(ListPersonas);
        }

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

                        oPersonas.Id = Convert.ToInt32(reader["Id"]);
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

        public ActionResult CrearEmpleado(string Cedula, string Nombres, string Apellido1, string Apellido2, string Ciudad,
            string Departamento, string Direccion, string Celular, string Correo)
        {
            string Query = "INSERT INTO Personas(Documento, Nombres, Apellido1, Apellido2, Ciudad, Departamento, Direccion, Celular, Email)" +
                           $" VALUES('{Cedula}', '{Nombres}', '{Apellido1}', '{Apellido2}', '{Ciudad}','{Departamento}', '{Direccion}', '{Celular}', '{Correo}')";

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(Query, cn);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception Ex)
                {
                    throw new Exception("Hay un error en el query" + Ex.Message);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EliminarEmpleado(int Id)
        {
            string Query = $"DELETE Personas WHERE Id = '{Id}'";

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand(Query, cn);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception Ex)
                {
                    throw new Exception("Hay un error en el query" + Ex.Message);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}