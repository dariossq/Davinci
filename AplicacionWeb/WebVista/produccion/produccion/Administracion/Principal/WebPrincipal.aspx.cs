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
        CCompraRepository compra = new CCompraRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        } 
    }
}