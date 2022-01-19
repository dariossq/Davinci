using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CCompra
{
    public class CCompra
    {
        #region

        private String campannasId;
        private String campannasNombre;
        private String campannasApellidos;
        private String campannasProducto;
        private String campannasTelefono;
        private String campannasDirecion;
        //private String campannasCodigo;

        #endregion

        #region metodos get y set
        public string CampannasId { get => campannasId; set => campannasId = value; }
        public string CampannasNombre { get => campannasNombre; set => campannasNombre = value; }
        public string CampannasApellidos { get => campannasApellidos; set => campannasApellidos = value; }
        public string CampannasProducto { get => campannasProducto; set => campannasProducto = value; }
        public string CampannasTelefono { get => campannasTelefono; set => campannasTelefono = value; }
        public string CampannasDirecion { get => campannasDirecion; set => campannasDirecion = value; }
        //public string CampannasCodigo { get => campannasCodigo; set => campannasCodigo = value; }
       

        #endregion

        #region constructor        
        public CCompra(DataTable Campanna, int fila)
        {
           
            //this.CampannasId = Campanna.Rows[fila]["Id"].ToString().ToUpper();
            this.CampannasNombre = Campanna.Rows[fila]["CAMPANNASNOMBRE"].ToString().ToUpper();
            this.CampannasApellidos = Campanna.Rows[fila]["CAMPANNASAPELLIDOS"].ToString().ToUpper();
            this.CampannasTelefono = Campanna.Rows[fila]["CAMPANNASTELEFONO"].ToString().ToUpper();
            this.CampannasDirecion = Campanna.Rows[fila]["CAMPANNASDIRECCION"].ToString().ToUpper();
            this.campannasProducto = Campanna.Rows[fila]["CAMPANNAPRODUCTO"].ToString().ToUpper();           
            //this.CampannasCodigo = Campanna.Rows[fila]["CAMPANNACODIGO"].ToString().ToUpper();
        }


        #endregion
    }
}
