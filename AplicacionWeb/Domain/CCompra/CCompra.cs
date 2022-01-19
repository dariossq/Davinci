using System;
using System.Data;

namespace Domain.CCompra
{
    public class CCompra
    {
        #region

        private string campannasId;
        private string campannasNombre;
        private string campannasApellidos;
        private string campannasProducto;
        private string campannasTelefono;
        private string campannasDirecion;
        private string campannasCodigo;

        #endregion

        #region metodos get y set
        public string CampannasId { get => campannasId; set => campannasId = value; }
        public string CampannasNombre { get => campannasNombre; set => campannasNombre = value; }
        public string CampannasApellidos { get => campannasApellidos; set => campannasApellidos = value; }
        public string CampannasProducto { get => campannasProducto; set => campannasProducto = value; }
        public string CampannasTelefono { get => campannasTelefono; set => campannasTelefono = value; }
        public string CampannasDirecion { get => campannasDirecion; set => campannasDirecion = value; }
        public string CampannasCodigo { get => campannasCodigo; set => campannasCodigo = value; }


        #endregion

        #region constructor        
        public CCompra(DataTable Campanna, int fila)
        {
            try
            {
                CampannasId = Campanna.Rows[fila]["iD"].ToString().ToUpper();
            }
            catch (Exception)
            { }

            try
            {
                CampannasNombre = Campanna.Rows[fila]["CAMPANNASNOMBRE"].ToString().ToUpper();
            }
            catch (Exception)
            { }

            try
            {
                CampannasApellidos = Campanna.Rows[fila]["CAMPANNASAPELLIDOS"].ToString().ToUpper();
            }
            catch (Exception)
            { }

            try
            {
                CampannasTelefono = Campanna.Rows[fila]["CAMPANNASTELEFONO"].ToString().ToUpper();
            }
            catch (Exception)
            { }

            try
            {
                CampannasDirecion = Campanna.Rows[fila]["CAMPANNASDIRECCION"].ToString().ToUpper();
            }
            catch (Exception)
            { }

            try
            {
                campannasProducto = Campanna.Rows[fila]["CAMPANNAPRODUCTO"].ToString().ToUpper();
            }
            catch (Exception)
            { }

            try
            {
                CampannasCodigo = Campanna.Rows[fila]["CAMPANNACODIGO"].ToString().ToUpper();
            }
            catch (Exception)
            { }

        }


        #endregion
    }
}
