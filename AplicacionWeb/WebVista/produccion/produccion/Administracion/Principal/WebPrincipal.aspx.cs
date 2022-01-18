using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infrastruture.RCompra;

namespace WebVista.produccion.produccion.Administracion.Principal
{
    public partial class WebPrincipal : System.Web.UI.Page
    {
        //int empresa_id;
        CCompraRepository compra = new CCompraRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            //empresa_id = (int)Session["empresa_id"];
            //object holas = null;
            //bool hola = compra.Save(holas);
        }

        //public dynamic Datos()
        //{
        //    dynamic DatosPersona = new System.Dynamic.ExpandoObject();

        //    try
        //    {
        //        if (string.IsNullOrEmpty(HfIdUsuario.Value))
        //        {
        //            DatosPersona.id = 0;
        //        }
        //        else
        //        {
        //            DatosPersona.id = Convert.ToInt32(HfIdUsuario.Value);
        //        }

        //        if (string.IsNullOrEmpty(TxtNombre.Text))
        //        {
        //            DatosPersona.Nombre = 0;
        //        }
        //        else
        //        {
        //            DatosPersona.Nombre = TxtNombre.Text;
        //        }

        //        if (string.IsNullOrEmpty(TxtfechaNac.Text))
        //        {
        //            DatosPersona.FechaNacimiento = "";
        //        }
        //        else
        //        {
        //            DatosPersona.FechaNacimiento = Convert.ToDateTime(TxtfechaNac.Text);
        //        }

        //        if (string.IsNullOrEmpty(DdlSexo.SelectedValue))
        //        {
        //            DatosPersona.Sexo = "";
        //        }
        //        else
        //        {
        //            DatosPersona.Sexo = DdlSexo.SelectedValue;
        //        }

        //        return DatosPersona;
        //    }
        //    catch (Exception)
        //    {
        //        return DatosPersona;
        //    }
        //}

    }
}