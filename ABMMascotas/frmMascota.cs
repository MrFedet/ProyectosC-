using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//CURSO – LEGAJO – APELLIDO – NOMBRE  1W4 113816 TAHAN FEDERICO YAMIL

namespace ABMMascotas
{
    public partial class frmMascota : Form
    {
        accessDB oDB = new accessDB();
        List<Mascota> mascotaList = new List<Mascota>();
        public frmMascota()
        {
            InitializeComponent();
        }

        private void frmMascota_Load(object sender, EventArgs e)
        {
            habilitar(false);
            cargar_cbo("Select * from Especies", cboEspecie, "nombreEspecie", "idEspecie");
            cargar_lista(lstMascotas, "Mascotas");
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            vaciar_campos();
            habilitar(true);
            txtCodigo.Focus();
        }
        private void habilitar(bool a)
        {
            btnNuevo.Enabled = !a;
            txtCodigo.Enabled = a;
            txtNombre.Enabled = a;
            btnGrabar.Enabled = a;
            cboEspecie.Enabled = a;
            rbtHembra.Enabled = a;
            rbtMacho.Enabled = a;
            dtpFechaNacimiento.Enabled = a;
            lstMascotas.Enabled = false;

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar_campos())
            {
                if (MessageBox.Show("Desea cargar esta mascota a la base de datos?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    grabar_db();
                    MessageBox.Show("Se ha cargado la mascota con exito");
                    vaciar_campos();
                    habilitar(false);
                    cargar_lista(lstMascotas, "Mascotas");

                }
                else
                {
                    habilitar(false);
                    vaciar_campos();
                }
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro que desea salir del programa?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cargar_cbo(string query, ComboBox cbo, string display, string value)
        {
            cbo.DataSource = oDB.accederDB(query);
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cargar_lista(ListBox list, string tabla)
        {
            mascotaList.Clear();

            oDB.leerDB("Select * from " + tabla);
            while (oDB.Lector.Read())
            {
                Mascota m = new Mascota();
                if (!oDB.Lector.IsDBNull(0))
                {
                    m.pCodigo = oDB.Lector.GetInt32(0);
                }
                if (!oDB.Lector.IsDBNull(1))
                {
                    m.pNombre = oDB.Lector.GetString(1);
                }
                mascotaList.Add(m);
            }
            oDB.desconectar();
            list.Items.Clear();
            for(int i = 0; i < mascotaList.Count; i++)
            {
                list.Items.Add(mascotaList[i].ToString());
            }
        }

        private bool validar_campos()
        {
            if(txtCodigo.Text == "" )
            {
                MessageBox.Show("Debe ingresar el codigo de la mascota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
                return false;
            }else if (existedb("Mascotas", txtCodigo.Text))
            {
                MessageBox.Show("El codigo ingresado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el Nombre de la mascota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!rbtHembra.Checked && !rbtMacho.Checked)
            {
                MessageBox.Show("Debe ingresar el Sexo de la mascota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (DateTime.Now.Year - dtpFechaNacimiento.Value.Year > 10)
            {
                MessageBox.Show("La Mascota no puede tener mas de 10 Años", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtCodigo.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe ingresar un valor numerico");
                    txtCodigo.Focus();
                    return false;

                }
            }

            return true;
        }

        public bool existedb(string table, string usuario)
        {
            oDB.leerDB("Select codigo from " + table);
            while (oDB.Lector.Read())
            {
                if(Convert.ToString(oDB.Lector.GetInt32(0)) == usuario)
                {
                    oDB.desconectar();
                    return true;
                }
            }
            oDB.desconectar();
            return false;
        }
        public void vaciar_campos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            cboEspecie.SelectedIndex = -1;
            rbtHembra.Checked = false;
            rbtMacho.Checked = false;
            dtpFechaNacimiento.Value = DateTime.Now;
        }




    }
}
