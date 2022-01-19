using Domain.CCompra;
using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace Infrastruture.RCompra
{
    public class CCompraRepository
    {
        private readonly string connectionString;
        private readonly DataTable Dt = new DataTable();
        private readonly DataSet Ds = new DataSet();
        public CCompraRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
        }

        /// <summary>
        /// Metodo para guardar informacion
        /// </summary>
        /// <param name="Campanna"></param>
        /// <returns></returns>

        public bool Save(DataTable Campanna, int ConstruirSql)
        {
            try
            {
                bool valor = false;
                int codigo = UltimoRegistroCodigo();
                int n = 0;

                if (Campanna.Rows.Count > 0)
                {
                    int Aux = Campanna.Rows.Count;
                    while (n < Campanna.Rows.Count)
                    {
                        CCompra compana = new CCompra(Campanna, n);
                        DataSet Ds = new DataSet();
                        using (OracleConnection conn = new OracleConnection(connectionString))
                        {
                            try
                            {
                                conn.Open();
                                OracleCommand command = conn.CreateCommand();
                                command.CommandText = "insert into CAMPANNAS ( CAMPANNASNOMBRE, CAMPANNASAPELLIDOS,CAMPANNASTELEFONO,CAMPANNASDIRECCION,CAMPANNAPRODUCTO,CAMPANNACODIGO)" +
                                "VALUES ('" + compana.CampannasNombre + "', '" + compana.CampannasApellidos + "'  , '" + compana.CampannasTelefono + "' , '" + compana.CampannasDirecion + "', '" + compana.CampannasProducto + "',  " + codigo + " )";

                                OracleDataAdapter sqlDa = new OracleDataAdapter(command);
                                command.ExecuteNonQuery();
                                n++;
                                if (n == Aux)
                                {
                                    return valor = true;
                                }                               
                            }
                            catch (Exception)
                            {
                                return valor;
                            }
                            finally
                            {
                                conn.Close();
                            }

                        }
                    }
                    return valor;
                }
                else
                {
                    return false;                   
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// metodo boolean para actualizar informacion
        /// </summary>
        /// <param name="Campanna"></param>
        /// <returns></returns>
        public bool Update(DataTable Campanna)
        {
            try
            {
                int n = 0;
                CCompra compana = new CCompra(Campanna, n);
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        OracleCommand command = conn.CreateCommand();
                        command.CommandText = "UPDATE CAMPANNAS  SET CAMPANNASNOMBRE = '" + compana.CampannasNombre + "', " +
                                                                    "CAMPANNASAPELLIDOS = '" + compana.CampannasApellidos + "', " +
                                                                     "CAMPANNASTELEFONO = '" + compana.CampannasTelefono + "', " +
                                                                      "CAMPANNASDIRECCION = '" + compana.CampannasDirecion + "', " +
                                                                       "CAMPANNAPRODUCTO = '" + compana.CampannasProducto + "', " +
                                                                   "CAMPANNACODIGO = '" + compana.CampannasCodigo + "' " +
                                               " WHERE  CAMPANNASID = '" + compana.CampannasId + "' ";
                        command.ExecuteNonQuery();
                        return true;

                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para eliminar un registro seleccionado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Del(DataTable Campanna)
        {
            int n = 0;
            CCompra compana = new CCompra(Campanna, n);

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OracleCommand command = conn.CreateCommand();
                    command.CommandText = "DELETE CAMPANNAS WHERE CAMPANNASID = '" + compana.CampannasId + "'";
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Metodo para saber que codigo es el mayor insertado y aunmenta en 1 dicho codigo
        /// </summary>
        /// <returns></returns>

        public int UltimoRegistroCodigo()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                int codigo = 0;
                try
                {
                    conn.Open();
                    OracleCommand command = conn.CreateCommand();
                    command.CommandText = @"select  max(campannacodigo) from campannas  order by   campannacodigo DESC";
                    OracleDataAdapter sqlDa = new OracleDataAdapter(command);
                    command.ExecuteNonQuery();

                    sqlDa.Fill(Dt);
                    codigo = Convert.ToInt16(Dt.Rows[0][0].ToString());
                    codigo++;
                    return codigo;
                }

                catch (Exception)
                {
                    codigo++;
                    return codigo;
                }
                finally
                {
                    // siempre se ejecuta al finalizar (no importa si hay o no errores)
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Metodo para mostrar datos
        /// </summary>
        /// <returns></returns>
        public DataSet MostrarDatos()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OracleCommand command = conn.CreateCommand();

                    command.CommandText = @"select  * from campannas  order by   campannacodigo DESC";
                    OracleDataAdapter sqlDa = new OracleDataAdapter(command);
                    command.ExecuteNonQuery();
                    sqlDa.Fill(Ds);
                    return Ds;
                }
                catch (Exception)
                {
                    return Ds;
                }
                finally
                {                   
                    conn.Close();
                }

            }
        }
    }
}
