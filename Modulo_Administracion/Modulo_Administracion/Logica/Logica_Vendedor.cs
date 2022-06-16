using Modulo_Administracion.Clases;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Modulo_Administracion.Logica
{
    static class Logica_Vendedor
    {



        public static bool alta_vendedor(vendedor vendedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {

                    vendedor vendedor_a_insertar = new vendedor();
                    int cantidad = db.vendedor.Count();
                    if (cantidad == 0)
                    {
                        vendedor_a_insertar.id_vendedor = 1;
                    }
                    else
                    {
                        vendedor_a_insertar.id_vendedor = db.vendedor.Max(v => v.id_vendedor) + 1;
                    }
                    vendedor_a_insertar.nombre = vendedor.nombre;
                    vendedor_a_insertar.sn_activo = vendedor.sn_activo;
                    vendedor_a_insertar.fec_ult_modif = vendedor.fec_ult_modif;
                    vendedor_a_insertar.accion = vendedor.accion;

                    db.vendedor.Add(vendedor_a_insertar);
                    db.SaveChanges();


                    bandera = true;
                    dbContextTransaction.Commit();
                    return bandera;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    db = null;
                }
            }
        }

        public static bool modificar_vendedor(vendedor vendedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {

                    vendedor vendedor_db = db.vendedor.FirstOrDefault(f => f.id_vendedor == vendedor.id_vendedor);
                    vendedor_db.id_vendedor = vendedor.id_vendedor;
                    vendedor_db.nombre = vendedor.nombre;
                    vendedor_db.sn_activo = vendedor.sn_activo;
                    vendedor_db.accion = "MODIFICACION";
                    vendedor_db.fec_ult_modif = DateTime.Now;
                    db.SaveChanges();


                    dbContextTransaction.Commit();
                    bandera = true;
                    return bandera;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    db = null;
                }
            }
        }

        public static bool dar_de_baja_vendedor(vendedor vendedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {


                    vendedor vendedor_db = db.vendedor.FirstOrDefault(f => f.id_vendedor == vendedor.id_vendedor);
                    vendedor_db.id_vendedor = vendedor.id_vendedor;
                    vendedor_db.nombre = vendedor.nombre;
                    vendedor_db.sn_activo = 0;
                    vendedor_db.accion = "ELIMINACION";
                    vendedor_db.fec_ult_modif = DateTime.Now;
                    db.SaveChanges();


                    dbContextTransaction.Commit();
                    bandera = true;
                    return bandera;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    db = null;
                }
            }
        }

        public static List<vendedor> buscar_vendedores_activos()
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {


                List<vendedor> vendedores = (from v in db.vendedor
                                             where v.sn_activo == -1
                                             select v).ToList();


                return vendedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }


        public static vendedor buscar_vendedores_activos_con_Nombre_repetido(string nombre, int id_vendedor)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                vendedor vendedor = db.vendedor.FirstOrDefault(p => p.nombre == nombre && 
                                                                    p.sn_activo == -1 && 
                                                                    p.id_vendedor != id_vendedor);

                return vendedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }


        public static vendedor buscar_vendedor(int? id_vendedor)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                vendedor vendedor = db.vendedor.FirstOrDefault(p => p.id_vendedor == id_vendedor);

                return vendedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }


        public static DataTable buscar_vendedores_activos(string txtBusqueda)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                connection.Open();
                using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                {

                    try
                    {

                        DataSet ds = new DataSet();

                        //store
                        SqlCommand command = new SqlCommand("vendedor_buscar_activos", connection, sqlTransaction);

                        //parametros
                        command.Parameters.AddWithValue("@nombre", txtBusqueda.Trim());


                        //tiempo y tipo
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = command;
                        adapter.Fill(ds);

                        sqlTransaction.Commit();
                        return ds.Tables[0];

                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
