
using Infrastruture.RCompra;
using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVista.produccion.produccion.Administracion.Campanna
{
    public partial class WebCampanna : System.Web.UI.Page
    {
        private readonly Infrastruture.RCompra.CCompraRepository Campa = new CCompraRepository();
        private DataSet Ds = new DataSet();
        private readonly int mostrar = 0;
        public enum MessageType { Mensaje, Error, Informacion, Advertencia };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }
            else
            {
                CargarCampanna();
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
               
                string conexion = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=C:\\Users\\User-Pc\\Downloads\\Importacion_CSharp\\Importacion_CSharp\\Excel_BD.xlsx;Extended Properties=\"Excel 8.0; HDR=Yes\"";
                OleDbConnection origen = default(OleDbConnection);
                origen = new OleDbConnection(conexion);
                OleDbCommand seleccion = default(OleDbCommand);
                seleccion = new OleDbCommand("Select * From [Hoja1$]", origen);

                OleDbDataAdapter adaptador = new OleDbDataAdapter
                {
                    SelectCommand = seleccion
                };

                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                origen.Close();
                dt = EliminarColunmasNoSeleccionadas(dt);

                if (Campa.Save(dt, mostrar))
                {
                    CargarCampanna();
                    ShowMessage("Datos guardados satisfactoriamente", MessageType.Informacion);
                }
            }
            catch (Exception)
            {
                ShowMessage("Por favor selecciona el archivo de contiene los datos a importar", MessageType.Advertencia);
            }
        }

        /// <summary>
        /// Método para eliminar las columnas del DT creado
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable EliminarColunmasNoSeleccionadas(DataTable dt)
        {
            try
            {
                if (CbNomre.SelectedValue != "" && CbApellido.SelectedValue == "" && CbDireccion.SelectedValue == "" && CbTelefono.SelectedValue == "")
                {
                    dt.Columns.Remove("CAMPANNASAPELLIDOS");
                    dt.Columns.Remove("CAMPANNASTELEFONO");
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue != "" && CbApellido.SelectedValue != "" && CbDireccion.SelectedValue == "" && CbTelefono.SelectedValue == "")
                {
                    dt.Columns.Remove("CAMPANNASTELEFONO");
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue != "" && CbApellido.SelectedValue != "" && CbDireccion.SelectedValue != "" && CbTelefono.SelectedValue == "")
                {
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue != "" && CbApellido.SelectedValue != "" && CbDireccion.SelectedValue != "" && CbTelefono.SelectedValue != "")
                {
                    return dt;
                }
                else

                   if (CbNomre.SelectedValue == "" && CbApellido.SelectedValue != "" && CbDireccion.SelectedValue == "" && CbTelefono.SelectedValue == "")
                {
                    dt.Columns.Remove("CAMPANNASNOMBRE");
                    dt.Columns.Remove("CAMPANNASTELEFONO");
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue == "" && CbApellido.SelectedValue != "" && CbDireccion.SelectedValue != "" && CbTelefono.SelectedValue == "")
                {
                    dt.Columns.Remove("CAMPANNASNOMBRE");
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue == "" && CbApellido.SelectedValue != "" && CbDireccion.SelectedValue != "" && CbTelefono.SelectedValue != "")
                {
                    dt.Columns.Remove("CAMPANNASNOMBRE");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue == "" && CbApellido.SelectedValue != "" && CbDireccion.SelectedValue == "" && CbTelefono.SelectedValue != "")
                {
                    dt.Columns.Remove("CAMPANNASNOMBRE");
                    dt.Columns.Remove("CAMPANNASTELEFONO");
                    return dt;
                }
                else

                   if (CbNomre.SelectedValue != "" && CbApellido.SelectedValue == "" && CbDireccion.SelectedValue != "" && CbTelefono.SelectedValue == "")
                {
                    dt.Columns.Remove("CAMPANNASAPELLIDOS");
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue == "" && CbApellido.SelectedValue == "" && CbDireccion.SelectedValue != "" && CbTelefono.SelectedValue != "")
                {
                    dt.Columns.Remove("CAMPANNASNOMBRE");
                    dt.Columns.Remove("CAMPANNASAPELLIDOS");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue != "" && CbApellido.SelectedValue == "" && CbDireccion.SelectedValue == "" && CbTelefono.SelectedValue != "")
                {
                    dt.Columns.Remove("CAMPANNASNOMBRE");
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue == "" && CbApellido.SelectedValue == "" && CbDireccion.SelectedValue == "" && CbTelefono.SelectedValue != "")
                {
                    dt.Columns.Remove("CAMPANNASNOMBRE");
                    dt.Columns.Remove("CAMPANNASAPELLIDOS");
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }

                else
                    if (CbNomre.SelectedValue != "" && CbApellido.SelectedValue == "" && CbDireccion.SelectedValue != "" && CbTelefono.SelectedValue != "")
                {
                    dt.Columns.Remove("CAMPANNASAPELLIDOS");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue != "" && CbApellido.SelectedValue != "" && CbDireccion.SelectedValue == "" && CbTelefono.SelectedValue != "")
                {
                    dt.Columns.Remove("CAMPANNASDIRECCION");
                    return dt;
                }
                else
                    if (CbNomre.SelectedValue == "" && CbApellido.SelectedValue == "" && CbDireccion.SelectedValue != "" && CbTelefono.SelectedValue == "")
                {
                    dt.Columns.Remove("CAMPANNASNOMBRE");
                    dt.Columns.Remove("CAMPANNASAPELLIDOS");
                    dt.Columns.Remove("CAMPANNASTELEFONO");
                    return dt;
                }
                return dt;
            }
            catch (Exception)
            {
                return dt;
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

        private void SaveFile(HttpPostedFile file)
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

        /// <summary>
        /// Méetodo para listar todos los autores registrados
        /// </summary>
        private void CargarCampanna()
        {
            try
            {
                Ds = Campa.MostrarDatos();
                GvDatos.DataSource = Ds;
                GvDatos.DataBind();
            }
            catch (Exception)
            {
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
            ActivarBotones();
            ActivarPanel();
        }

        /// <summary>
        /// Métido para limpiar los Txt
        /// </summary>
        private void LimpiarTxt()
        {
            HfId.Value = "";
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            TxtDireccion.Text = "";
            TxtTelefono.Text = "";
            TxtProducto.Text = "";
            TxtCodigo.Text = "";
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
            HfId.Value = GvDatos.SelectedDataKey["CAMPANNASID"].ToString();
            TxtNombre.Text = GvDatos.SelectedDataKey["CAMPANNASNOMBRE"].ToString();
            TxtApellido.Text = GvDatos.SelectedDataKey["CAMPANNASAPELLIDOS"].ToString();
            TxtTelefono.Text = GvDatos.SelectedDataKey["CAMPANNASTELEFONO"].ToString();
            TxtDireccion.Text = GvDatos.SelectedDataKey["CAMPANNASDIRECCION"].ToString();
            TxtProducto.Text = GvDatos.SelectedDataKey["CAMPANNAPRODUCTO"].ToString();
            TxtCodigo.Text = GvDatos.SelectedDataKey["CAMPANNACODIGO"].ToString();

            ActivarPanel();
        }

        /// <summary>
        /// Método para activar los paneles 
        /// </summary>
        private void ActivarPanel()
        {
            if (HfId.Value != "")
            {
                LblTitulo.InnerText = "Registro Seleccionado";
                PnCampos.Visible = true;
                PnCargarDatos.Visible = false;
            }
            else
            {
                LblTitulo.InnerText = "Campos a importar";
                PnCampos.Visible = false;
                PnCargarDatos.Visible = true;
            }

        }

        /// <summary>
        /// Metodo para activar botones
        /// </summary>
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

        protected void BtnActualiza_Click(object sender, EventArgs e)
        {
            if (Campa.Update(CrearTablaUdp()))
            {
                CargarCampanna();
                LimpiarTxt();
                ActivarBotones();
                ActivarPanel();
                ShowMessage("Datos guardados satisfactoriamente", MessageType.Informacion);
            }
        }

        /// <summary>
        /// Metod0 DT para crear la tabla a enviar 
        /// </summary>
        /// <returns></returns>
        private DataTable CrearTablaUdp()
        {
            DataTable Dt = new DataTable("Campanna");
            try
            {
                DataColumn ID = new DataColumn("ID");
                DataColumn CAMPANNASNOMBRE = new DataColumn("CAMPANNASNOMBRE");
                DataColumn CAMPANNASAPELLIDOS = new DataColumn("CAMPANNASAPELLIDOS");
                DataColumn CAMPANNASTELEFONO = new DataColumn("CAMPANNASTELEFONO");
                DataColumn CAMPANNASDIRECCION = new DataColumn("CAMPANNASDIRECCION");
                DataColumn CAMPANNAPRODUCTO = new DataColumn("CAMPANNAPRODUCTO");
                DataColumn CAMPANNACODIGO = new DataColumn("CAMPANNACODIGO");

                Dt.Columns.Add(ID);
                Dt.Columns.Add(CAMPANNASNOMBRE);
                Dt.Columns.Add(CAMPANNASAPELLIDOS);
                Dt.Columns.Add(CAMPANNASTELEFONO);
                Dt.Columns.Add(CAMPANNASDIRECCION);
                Dt.Columns.Add(CAMPANNAPRODUCTO);
                Dt.Columns.Add(CAMPANNACODIGO);

                DataRow row1 = Dt.NewRow();
                row1["ID"] = HfId.Value;
                row1["CAMPANNASNOMBRE"] = TxtNombre.Text;
                row1["CAMPANNASAPELLIDOS"] = TxtApellido.Text;
                row1["CAMPANNASTELEFONO"] = TxtTelefono.Text;
                row1["CAMPANNASDIRECCION"] = TxtDireccion.Text;
                row1["CAMPANNAPRODUCTO"] = TxtProducto.Text;
                row1["CAMPANNACODIGO"] = TxtCodigo.Text;

                Dt.Rows.Add(row1);
                return Dt;
            }
            catch (Exception)
            {

                return Dt;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (Campa.Del(CrearTablaUdp()))
            {
                CargarCampanna();
                LimpiarTxt();
                ActivarBotones();
                ActivarPanel();
                ShowMessage("Registro eliminado satisfactoriamente", MessageType.Informacion);
            }
        }

       

        protected void GvDatos_PageIndexChanging(object sender, EventArgs e)
        {

        }

        protected void GvDatos_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GvDatos.PageIndex = e.NewPageIndex;
            CargarCampanna();
        }       
    }
}

