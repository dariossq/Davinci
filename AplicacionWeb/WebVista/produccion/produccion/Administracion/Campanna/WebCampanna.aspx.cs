
//using Microsoft.Graph;
using Newtonsoft.Json;
//using ReRopository.AutorRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
//using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Text.Json.Net;
using Infrastruture.RCompra;
using System.Data.OleDb;
using System.IO;

namespace WebVista.produccion.produccion.Administracion.Campanna
{
    public partial class WebCampanna : System.Web.UI.Page
    {
        Infrastruture.RCompra.CCompraRepository Campa = new CCompraRepository();
        DataSet Ds = new DataSet();
        dynamic Campanna = new System.Dynamic.ExpandoObject();
       // string url = ConfigurationManager.AppSettings["ApiAutor"];

        public enum MessageType { Mensaje, Error, Informacion, Advertencia };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }
            else
            {
               
                //CargarAutores(url);
                //CargarAutor();
            }
        }


        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                //HttpContext.Current.Request.MapPath("~");

                //string ok = Server.MapPath(".") + "/" + FileUpload1.FileName;
                //string ruta = (FileUpload1.PostedFile.FileName);
                //string nombre = FileUpload1.FileName;
                //string extensión = Right(FileUpload1.PostedFile.ContentType.Trim, 3);
                
                //C:\\Users\\User - Pc\\Documents\\GitHub\\Davinci\\Davinci\\AplicacionWeb\\WebVista\\produccion\\produccion\\Administracion\\Campanna\\Excel_BD.xlsx
                                                                                 //C:\\Users\\User-Pc\\Documents\\GitHub\\Davinci\\Davinci\\AplicacionWeb\\WebVista\\produccion\\produccion\\Administracion\\Campanna\\Excel_BD.xlsx
                string RutaArchivo = AsignarRuta();
                RutaArchivo = RutaArchivo.Replace(" ", String.Empty);
                //string conexion = "Provider=Microsoft.Jet.OleDb.4.0; Data Source= " + RutaArchivo + ";Extended Properties=\"Excel 8.0; HDR=Yes\"";
                string conexion = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=C:\\Users\\User-Pc\\Downloads\\Importacion_CSharp\\Importacion_CSharp\\Excel_BD.xlsx;Extended Properties=\"Excel 8.0; HDR=Yes\"";

                OleDbConnection origen = default(OleDbConnection);
                origen = new OleDbConnection(conexion);

                OleDbCommand seleccion = default(OleDbCommand);
                seleccion = new OleDbCommand("Select * From [Hoja1$]", origen);

                OleDbDataAdapter adaptador = new OleDbDataAdapter();
                adaptador.SelectCommand = seleccion;

                DataTable dt = new DataTable();

               

                adaptador.Fill(dt);


                
                //dt.Columns.Remove("CAMPANNASNOMBRE");
                //dt.Columns.Remove("CAMPANNASAPELLIDOS");
                //dt.Columns.Remove("CAMPANNASTELEFONO");
                //dt.Columns.Remove("CAMPANNASDIRECCION");
                
                origen.Close();

                //DataTable Dt = Campa.FechaServidor();
                //DateTime fecha = Convert.ToDateTime(Dt.Rows[0][0].ToString()); 

                Campa.Save(dt);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        private string AsignarRuta()
        {
            SaveFile(FileUpload1.PostedFile);
            string RutaArchivo = Server.MapPath(".") + "\\" + FileUpload1.FileName;
            string ruta = (FileUpload1.PostedFile.FileName);
            string nombre = FileUpload1.FileName;

            return RutaArchivo;
        }

        void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            string savePath = Server.MapPath(".");

            // Get the name of the file to upload.
            string fileName = FileUpload1.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }

                fileName = tempfileName;

                // Notify the user that the file name was changed.
                //UploadStatusLabel.Text = "A file with the same name already exists." +
                  //  "<br />Your file was saved as " + fileName;
            }
            else
            {
                // Notify the user that the file was saved successfully.
                //UploadStatusLabel.Text = "Your file was uploaded successfully.";
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            FileUpload1.SaveAs(savePath);

        }



        public void ExcelToSqlServer()
        {
            //System.Windows.Forms.OpenFileDialog myFileDialog = new System.Windows.Forms.OpenFileDialog();
            //string xSheet = "";

            //{
            //    var withBlock = myFileDialog;
            //    withBlock.Filter = "Excel Files |*.xlsx";
            //    withBlock.Title = "Open File";
            //    withBlock.ShowDialog();
            //}

            //if (myFileDialog.FileName.ToString != "")
            //{
            //    string ExcelFile = myFileDialog.FileName.ToString;
            //    xSheet = Interaction.InputBox("Digite el nombre de la Hoja que desea importar", "Complete");
            //    conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "data source=" + ExcelFile + "; " + "Extended Properties='Excel 12.0 Xml;HDR=Yes'");

            //    try
            //    {
            //        conn.Open();
            //        da = new OleDbDataAdapter("SELECT Nombre FROM  [" + xSheet + "$]", conn);
            //        ds = new DataSet();
            //        da.Fill(ds);

            //        sqlBC = new SqlBulkCopy(cnn);
            //        sqlBC.DestinationTableName = "DatosPersonales";
            //        sqlBC.WriteToServer(ds.Tables(0));
            //    }
            //    catch (Exception ex)
            //    {
            //        Interaction.MsgBox("Error: " + ex.ToString(), MsgBoxStyle.Information, "Informacion");
            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //}
        }

        //public async void CargarAutor()
        //{
        //    try
        //    {
        //        DdlAutor.DataSource = null;
        //        DdlAutor.Items.Add("");
        //        //DdlAutor.DataSource = await autor.getAutores(url);
        //        DdlAutor.DataTextField = "NOMBRE_COMPLETO";
        //        DdlAutor.DataValueField = "ID_AUTOR";
        //        DdlAutor.DataBind();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        /// <summary>
        /// Méetodo para listar todos los autores registrados
        /// </summary>
        private async void CargarCampanna()
        {
            //try
            //{
            //    Ds = Campa.Save1()
            //    GvDatos.DataSource = Ds;
            //    GvDatos.DataBind();
            //}
            //catch (Exception)
            //{
            //}
        }

        private async void CargarAutore(string urlEntrada)
        {
            //try
            //{


            //    urlEntrada = urlEntrada.Remove(urlEntrada.Length - 2);
            //    string datos = "{'Table1': [ " +  await autor.getAutores(urlEntrada) + " ]}";
            //    DataSet dataSet1 = JsonConvert.DeserializeObject<DataSet>(datos);
            //    GvDatos.DataSource = dataSet1;
            //    GvDatos.DataBind();

            //    if (GvDatos.Rows.Count <= 0)
            //    {
            //        ShowMessage("No hay datos con la información suministrada. ", MessageType.Informacion);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }


        //public dynamic Datos()
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(HfId.Value))
        //        {
        //            Campanna.Id = 0;
        //        }
        //        else
        //        {
        //            Campanna.Id = Convert.ToInt32(HfId.Value);
        //        }

        //        if (string.IsNullOrEmpty(TxtNombre.Text))
        //        {
        //            Campanna.Nombre = 0;
        //        }
        //        else
        //        {
        //            Campanna.Nombre = TxtNombre.Text;
        //        }

        //        if (string.IsNullOrEmpty(TxtFechaNacimiento.Text))
        //        {
        //            Campanna.Apellidos = 0;
        //        }
        //        else
        //        {
        //            Campanna.Apellidos = TxtFechaNacimiento.Text;
        //        }

        //        if (string.IsNullOrEmpty(TxtCiudad.Text))
        //        {
        //            Campanna.Telefono = 0;
        //        }
        //        else
        //        {
        //            Campanna.Telefono = TxtCiudad.Text;
        //        }

        //        if (string.IsNullOrEmpty(TxtMail.Text))
        //        {
        //            Campanna.Direcion = 0;
        //        }
        //        else
        //        {
        //            Campanna.Direcion = TxtMail.Text;
        //        }

        //        return Campanna;
        //    }
        //    catch (Exception)
        //    {
        //        return Campanna;
        //    }
        //}

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
            ActivarBotones();
        }

        /// <summary>
        /// Métido para limpiar los Txt
        /// </summary>
        private void LimpiarTxt()
        {
            HfId.Value = "";
            //TxtCiudad.Text = "";
            //TxtFechaNacimiento.Text = "";
            //TxtNombre.Text = "";
            //TxtMail.Text = "";
            ActivarBotones();
        }

        protected void GvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionar();
            ActivarBotones();
        }

        /// <summary>
        /// Metodo para seleccionar informacion
        /// </summary>
        private void Seleccionar()
        {
            HfId.Value = GvDatos.SelectedDataKey["ID_AUTOR"].ToString();
            //TxtNombre.Text = GvDatos.SelectedDataKey["NOMBRE_COMPLETO"].ToString();
            //DateTime fechaExpedicion = Convert.ToDateTime(GvDatos.SelectedDataKey["FECHA_NACIMIENTO"].ToString());
            //TxtFechaNacimiento.Text = fechaExpedicion.ToString("dd/MM/yyyy");
            //TxtCiudad.Text = GvDatos.SelectedDataKey["CIUDAD_PROCEDENCIA"].ToString();
            //TxtMail.Text = GvDatos.SelectedDataKey["CORREOELECTRONICO"].ToString();
        }

        private void ActivarBotones()
        {
            if (string.IsNullOrEmpty(HfId.Value))
            {
                BtnRegistrar.Visible = true;
                BtnActualiza.Visible = false;
                BtnEliminar.Visible = false;
            }
            else
            {
                BtnActualiza.Visible = true;
                BtnEliminar.Visible = true;
                BtnRegistrar.Visible = false;
            }
        }

        protected async void BtnActualiza_Click(object sender, EventArgs e)
        {
            //var client = new HttpClient();
            //var url1 = url + "/" + HfAutorId.Value;
            //var productos = JsonConvert.SerializeObject(Datos());
            //bool datos = await autor.putAutores(url1, productos);

            //if (datos)
            //{
            //    LimpiarTxt();
            //    CargarAutores(url);
            //    ShowMessage("Datos actualizados correctamente. ", MessageType.Informacion);
            //    //CargarAutores();
                
            //}
            //else
            //{
            //    ShowMessage("Lo sentimos no se ha podigo actualizar la información. ", MessageType.Informacion);

            //}
        }

        protected async void BtnEliminar_Click(object sender, EventArgs e)
        {
            //var client = new HttpClient();
            //var url1 = url + "/" + HfAutorId.Value;
            //var productos = JsonConvert.SerializeObject(Datos());
            //bool datos = await autor.deleteAutores(url1);

            //if (datos)
            //{
            //    LimpiarTxt();
            //    CargarAutores(url);
            //    ShowMessage("Registro eliminado correctamente. ", MessageType.Informacion);
            //    //CargarAutores();

            //}
            //else
            //{
            //    ShowMessage("Lo sentimos no se ha podigo eliminar la información. ", MessageType.Informacion);

            //}
        }

        protected void DdlAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var urlAutor = url + "/" + DdlAutor.Text;
            //CargarAutore(urlAutor);
        }

        
    }
}

