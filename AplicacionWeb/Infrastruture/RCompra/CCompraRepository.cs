using Domain.CCompra;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
//using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.RCompra
{
    public class CCompraRepository
    {
        private string connectionString;


        public CCompraRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
        }

        /// <summary>
        /// Metodo para guardar informacion
        /// </summary>
        /// <param name="Campanna"></param>
        /// <returns></returns>
        public Boolean Save(DataTable Campanna)
        {
            try
            {
                string TrabajoCod = "0";

                if (Campanna.Rows.Count > 0)
                {
                    int n = 0;
                    while (n < Campanna.Rows.Count) 
                        {                        
                        CCompra compana = new CCompra(Campanna, n);
                        DataSet Ds = new DataSet();
                        using (OracleConnection conn = new OracleConnection(this.connectionString))
                        {
                            try
                            {
                                conn.Open();
                                OracleCommand command = conn.CreateCommand();
                                command.CommandText = "insert into CAMPANNAS ( CAMPANNASNOMBRE, CAMPANNASAPELLIDOS,CAMPANNASTELEFONO,CAMPANNASDIRECCION,CAMPANNAPRODUCTO,CAMPANNACODIGO)" +
                                    "VALUES ('" + compana.CampannasNombre + "', '" + compana.CampannasNombre + "'  , '" + compana.CampannasTelefono + "' , '" + compana.CampannasDirecion + "', '" + compana.CampannasProducto + "', '" + compana.CampannasCodigo + "')";
                                OracleDataAdapter sqlDa = new OracleDataAdapter(command);
                                command.ExecuteNonQuery();
                                
                                //return true;
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                            finally
                            {
                                conn.Close();
                            }
                            n++;
                        }
                    }
                    return true;
                }else
                {
                    return false;
                    //Mensaje
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public Boolean Save1(DataSet ds)
        {
            string TrabajoCod = "0";

            //CCompra compana = new CCompra(Campanna);
            DataSet Ds = new DataSet();
            using (OracleConnection conn = new OracleConnection(this.connectionString))
            {
                try
                {
                    string cadena = "Data Source=DESKTOP-PIB9MC0;Persist Security Info=True; Password=  CAMPANNA; User ID= CAMPANNA,Unicode=True";
                    //"VALUES ('" + com.CampannasApellidos + "', '" + com.CampannasDirecion + "'  , " + com.CampannasNombre + " )";
                    conn.Open();
                    //OracleCommand command = conn.CreateCommand();

                    //"DATA SOURCE=(DESCRIPTION = (   (CONNECT_DATA = (SERVER = DEDICATED)   (SERVICE_NAME = XE))); \r\n         \r\n         PASSWORD=  CAMPANNA; USER ID= CAMPANNA"
                    SqlBulkCopy importar = default(SqlBulkCopy);
                    importar = new SqlBulkCopy(cadena);
                    importar.DestinationTableName = "TABLA_USUARIO";
                    importar.WriteToServer(ds.Tables[0]);
                    //connectionString.Close();
                
                    //command.CommandText = "insert into CAMPANNAS ( CAMPANNASNOMBRE, CAMPANNASAPELLIDOS,CAMPANNAPRODUCTO,CAMPANNACODIGO)" +
                    //    "VALUES ('" + compana.CampannasNombre + "', '" + compana.CampannasApellidos + "', '" + compana.CampannasTelefono + "', '" + compana.CampannasApellidos + "' )";
                    //// "VALUES ('3', 'DD'  , 'DD' )";
                    //OracleDataAdapter sqlDa = new OracleDataAdapter(command);
                    //command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}
