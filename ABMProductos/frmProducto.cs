using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ABMProductos
{
    public partial class frmProducto : Form
    {
        AccesoDatos oBD = new AccesoDatos();
        List<Producto> lProductos = new List<Producto>(); //lista dinamica para n Productos

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cargarCombo(cboMarca, "Marcas");
            cargarLista(lstProducto, "Productos");
        }

        private void cargarLista(ListBox lista, string nombreTabla)
        {
            /* Copia del Combo!!!
            //            DataTable tabla = oBD.consultarBD("SELECT * FROM " + nombreTabla + " ORDER BY 2");
                        DataTable tabla = oBD.consultarBD("SELECT codigo,str(codigo)+'-'+detalle+' $'+str(precio) as info FROM " + nombreTabla);
                        lista.DataSource = tabla;
                        lista.ValueMember = tabla.Columns[0].ColumnName; 
                        lista.DisplayMember = tabla.Columns[1].ColumnName; 
            */

            lProductos.Clear();
            oBD.leerBD("SELECT * FROM " + nombreTabla);
            while (oBD.pLector.Read())
            {
                Producto p = new Producto();
                if (!oBD.pLector.IsDBNull(0))
                    p.pCodigo = oBD.pLector.GetInt32(0);
                if (!oBD.pLector.IsDBNull(1))
                    p.pDetalle = oBD.pLector.GetString(1);
                if (!oBD.pLector.IsDBNull(2))
                    p.pTipo = oBD.pLector.GetInt32(2);
                if (!oBD.pLector.IsDBNull(3))
                    p.pMarca = oBD.pLector.GetInt32(3);
                if (!oBD.pLector.IsDBNull(4))
                    p.pPrecio = oBD.pLector.GetDouble(4);
                if (!oBD.pLector.IsDBNull(5))
                    p.pFecha = oBD.pLector.GetDateTime(5);
                
                lProductos.Add(p);
            }
            oBD.desconectar();
            lista.Items.Clear();
            for (int i = 0; i < lProductos.Count; i++)
            {
                lista.Items.Add(lProductos[i].ToString());
            }
            lista.SelectedIndex = 0;
        }

        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = oBD.consultarBD("SELECT * FROM " + nombreTabla + " ORDER BY 2");
            combo.DataSource = tabla;
            combo.ValueMember = tabla.Columns[0].ColumnName; //"idMarca"
            combo.DisplayMember = tabla.Columns[1].ColumnName; //"nombreMarca"
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Validar datos!!!

            Producto p = new Producto();
            p.pCodigo = int.Parse(txtCodigo.Text);
            p.pDetalle = txtDetalle.Text;
            p.pMarca = (int)cboMarca.SelectedValue;
            if (rbtNoteBook.Checked)
                p.pTipo = 1;
            else
                p.pTipo = 2;
            p.pPrecio = double.Parse(txtPrecio.Text);
            p.pFecha = dtpFecha.Value;

            //validar existencia del producto!!!

            string insertSQL = "INSERT INTO Productos VALUES (" +
                                                        p.pCodigo + ",'" +
                                                        p.pDetalle + "'," +
                                                        p.pTipo + "," +
                                                        p.pMarca + "," +
                                                        p.pPrecio + ",'" +
                                                        p.pFecha.ToString("yyyy/MM/dd") + "')";

            oBD.actualizarBD(insertSQL);
            cargarLista(lstProducto, "Productos");
        }

        private void lstProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
