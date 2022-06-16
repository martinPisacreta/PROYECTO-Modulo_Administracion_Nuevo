using Modulo_Administracion.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Modulo_Administracion.Logica
{
    static class Logica_Articulo
    {
      
        
        public static void modificar_articulos_por_metodo_actualizar_porcentaje(DataTable dt)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                connection.Open();
                using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, sqlTransaction))
                    {
                        try
                        {


                            SqlCommand crear_tabla = new SqlCommand(
                                                                        "create table #tmp_articulos" +
                                                                        "(" +
                                                                            "id_articulo bigint, " +
                                                                            "precio_lista numeric(18, 4)" +
                                                                        ")", connection, sqlTransaction
                                                                    );

                            SqlCommand actualizar_precios = new SqlCommand(
                                                                            "update " +
                                                                                "art " +
                                                                            "set " +
                                                                                "art.precio_lista = tmp.precio_lista," +
                                                                                "art.fecha_ult_modif = GETDATE(),art.accion = 'MODIFICACION' " +
                                                                            "from	" +
                                                                                "articulo art inner join #tmp_articulos tmp on tmp.id_articulo = art.id_articulo", connection, sqlTransaction
                                                                            );

                            crear_tabla.ExecuteNonQuery();

                            bulkCopy.BulkCopyTimeout = 180;
                            bulkCopy.DestinationTableName = "#tmp_articulos";
                            bulkCopy.WriteToServer(dt);

                            actualizar_precios.ExecuteNonQuery();

                            sqlTransaction.Commit();
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

        //SI "busqueda" ES 1 -> BUSCO LOS ARTICULOS EXISTENTES EN LA BASE DE DATOS EN RELACION A LA TABLA #tmp_lista_precios_proveedor
        //SI "busqueda" ES 2 -> BUSCO LOS ARTICULOS INEEXISTENTES EN LA BASE DE DATOS EN RELACION A LA TABLA #tmp_lista_precios_proveedor
        public static DataSet buscar_articulos_en_relacion_a_tmpListaPreciosProveedor(DataTable dt, int busqueda, int id_proveedor)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                connection.Open();
                using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, sqlTransaction))
                    {
                        try
                        {



                            SqlCommand crear_tabla_tmp_lista_precios_proveedor = new SqlCommand(
                                                                                 "create table #tmp_lista_precios_proveedor" +
                                                                                 "(" +

                                                                                    "codigo_articulo nvarchar(255) NULL," +
                                                                                    "descripcion_articulo nvarchar(255) NULL," +
                                                                                    "precio_lista float NULL" +
                                                                                ")", connection, sqlTransaction
                                                                               );



                            crear_tabla_tmp_lista_precios_proveedor.ExecuteNonQuery();


                            bulkCopy.BulkCopyTimeout = 180;
                            bulkCopy.DestinationTableName = "#tmp_lista_precios_proveedor";
                            bulkCopy.WriteToServer(dt);


                            DataSet dataSet = new DataSet();

                            SqlCommand command = new SqlCommand("articulo_buscar_en_relacion_a_tmpListaPreciosProveedor", connection, sqlTransaction);
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@busqueda";
                            param.Value = busqueda;
                            param.SqlDbType = SqlDbType.Int;
                            command.Parameters.Add(param);

                            param = new SqlParameter();
                            param.ParameterName = "@id_proveedor";
                            param.Value = id_proveedor;
                            param.SqlDbType = SqlDbType.Int;
                            command.Parameters.Add(param);

                            command.CommandTimeout = 0;

                            command.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = command;
                            adapter.Fill(dataSet);

                            sqlTransaction.Commit();

                            return dataSet;

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

        public static DataSet alta_articulos_por_metodo_subida_excelMaxi(DataTable dt)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                connection.Open();
                using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, sqlTransaction))
                    {
                        try
                        {

                            bulkCopy.BulkCopyTimeout = 180;
                            bulkCopy.DestinationTableName = "articulo_tmp";
                            bulkCopy.WriteToServer(dt);


                            DataSet dataSet = new DataSet();

                            SqlCommand command = new SqlCommand("articulo_alta_por_metodo_subida_excelMaxi", connection, sqlTransaction);
                            command.CommandTimeout = 0;

                            command.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = command;
                            adapter.Fill(dataSet);

                            sqlTransaction.Commit();

                            return dataSet;

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



        public static DataSet buscar_articulos_activos(string codigo_articulo_marca, string codigo_articulo)
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
                        SqlCommand command = new SqlCommand("articulo_buscar_por_codigoArticuloMarca_codigoArticulo", connection, sqlTransaction);

                        //parametros
                        command.Parameters.AddWithValue("@codigo_articulo_marca", codigo_articulo_marca);
                        command.Parameters.AddWithValue("@codigo_articulo", codigo_articulo);

                        //tiempo y tipo
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = command;
                        adapter.Fill(ds);
                        sqlTransaction.Commit();
                        return ds;

                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
        
        public static bool dar_de_baja_articulos(int id_tabla_familia, Modulo_AdministracionContext db) //doy de baja los articulos de una familia
        {

            bool bandera = false;
            try
            {

                List<articulo> lista_articulos = (from p in db.articulo
                                                  where p.id_tabla_familia == id_tabla_familia
                                                  select p).ToList();

                if (lista_articulos != null)
                {
                    foreach (articulo p in lista_articulos)
                    {
                        //pongo en factura_detalle NULL en el id_articulo enviado por parametro -> ya que se da de baja ese articulo , pero debe seguir figurando en el detalle de factura
                        if (Logica_Factura_Detalle.modificar_facturaDetalle(p.id_articulo, db) == false)
                        {
                            throw new Exception("Error al modificar id articulo en factura detalle");
                        }

                        p.fec_baja = DateTime.Today;
                        p.fecha_ult_modif = DateTime.Now;
                        p.accion = "ELIMINACION";
                    }
                }

                db.SaveChanges();
                bandera = true;
                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


       

        public static DataSet buscar_articulos_activos(int id_proveedor, int id_tabla_marca, int id_tabla_familia, string cod_articulo, string descripcion)
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
                        SqlCommand command = new SqlCommand("articulo_buscar_por_idProveedor_idTablaMarca_idTablaFamilia_codArticulo_descripcionArticulo", connection, sqlTransaction);

                        //parametros
                        command.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                        command.Parameters.AddWithValue("@id_tabla_marca", id_tabla_marca);
                        command.Parameters.AddWithValue("@id_tabla_familia", id_tabla_familia);
                        command.Parameters.AddWithValue("@cod_articulo", cod_articulo);
                        command.Parameters.AddWithValue("@descripcion", descripcion);

                        //tiempo y tipo
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = command;
                        adapter.Fill(ds);
                        sqlTransaction.Commit();
                        return ds;

                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        throw ex;
                    }
                }
            }
        }


        public static DataSet buscar_articulos_activos()
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
                        SqlCommand command = new SqlCommand("articulo_buscar_activos", connection, sqlTransaction);



                        //tiempo y tipo
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = command;
                        adapter.Fill(ds);
                        sqlTransaction.Commit();
                        return ds;

                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static bool modificar_articulos_existentes_en_relacion_a_ListaProveedor(List<articulo> lista_articulo, Modulo_AdministracionContext db)
        {


            bool bandera = false;
            try
            {
                foreach (articulo a in lista_articulo)
                {
                    if (modificar_articulo(a, db) == false)
                    {
                        throw new Exception("Error al modificar los articulos");
                    }
                }

                bandera = true;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static bool modificar_articulo(articulo articulo, Modulo_AdministracionContext db)
        {
            try
            {

                bool bandera = false;
                articulo articulo_db = db.articulo.FirstOrDefault(f => f.id_articulo == articulo.id_articulo); //listo
                articulo_db.codigo_articulo = articulo.codigo_articulo;
                articulo_db.descripcion_articulo = articulo.descripcion_articulo;
                articulo_db.precio_lista = articulo.precio_lista;
                articulo_db.fecha_ult_modif = DateTime.Now;
                db.SaveChanges();
                bandera = true;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool alta_articulos_inexistentes_en_relacion_a_ListaProveedor(List<articulo> lista_articulo, Modulo_AdministracionContext db)
        {


            bool bandera = false;
            try
            {
                foreach (articulo articulo in lista_articulo)
                {
                    if (alta_articulo(articulo, db) == false)
                    {
                        throw new Exception("Error al dar de alta los articulos");
                    }
                }
                bandera = true;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool alta_articulo(articulo articulo, Modulo_AdministracionContext db)
        {
            try
            {
                bool bandera = false;
                articulo articulo_a_insertar = new articulo();
                familia familia_articulo = Logica_Familia.buscar_familia(articulo.id_tabla_familia.Value);

                //id_articulo es identity
                articulo_a_insertar.codigo_articulo_marca = familia_articulo.marca.txt_desc_marca;
                articulo_a_insertar.codigo_articulo = articulo.codigo_articulo;
                articulo_a_insertar.descripcion_articulo = articulo.descripcion_articulo;
                articulo_a_insertar.precio_lista = articulo.precio_lista;
                articulo_a_insertar.id_tabla_familia = articulo.id_tabla_familia;
                articulo_a_insertar.sn_oferta = 0;
                articulo_a_insertar.path_img = "";
                articulo_a_insertar.fecha_ult_modif = DateTime.Now;
                articulo_a_insertar.fec_baja = null;
                articulo_a_insertar.accion = "ALTA";

                int cantidad = db.articulo.Count();
                if (cantidad == 0)
                {
                    articulo_a_insertar.id_orden = 1;
                }
                else
                {
                    articulo_a_insertar.id_orden = db.articulo.Max(a => a.id_orden) + 1;
                }
                db.articulo.Add(articulo_a_insertar);
                db.SaveChanges();

                bandera = true;
                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
