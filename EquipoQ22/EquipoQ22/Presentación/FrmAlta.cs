using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EquipoQ22.Datos;
using EquipoQ22.Servicio.Interfaz;
using EquipoQ22.Servicio.Implementacion;
using EquipoQ22.Domino;


//COMPLETAR --> Curso:1W4      Legajo:     113816    Apellido y Nombre: TAHAN FEDERICO YAMIL

//CadenaDeConexion: "Data Source=sqlgabineteinformatico.frc.utn.edu.ar;Initial Catalog=Qatar2022;User ID=alumnoprog22;Password=SQL+Alu22"

namespace EquipoQ22
{
    public partial class FrmAlta : Form
    {

        private IS_EquipoDao serv;
        Equipo eq = new Equipo();
        public FrmAlta()
        {
            serv = new S_EquipoDao();
            InitializeComponent();
        }
        private void FrmAlta_Load(object sender, EventArgs e)
        {
            CargarPersonas();
            lblTotal.Text = "Total de Jugadores: 0";
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Jugador j = new Jugador();
            j.Persona = (Persona)cboPersona.SelectedItem;
            j.Posicion = cboPosicion.Text;
            j.Camiseta = Convert.ToInt32(nudCamiseta.Value);
            if (validar_Jugador(j))
            {
              eq.AgregarDetalle(j);
              Agregar_datagrid(dgvDetalles);
            }
            lblTotal.Text = " Total de Jugadores:" + Convert.ToString(eq.LPersonas.Count());
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar_Eq())
            {
                eq.Director = txtDT.Text;
                eq.Pais = txtPais.Text;
                if (serv.CrearEquipo(eq))
                {
                    MessageBox.Show("Equipo Cargado con exito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se ha podido cargar el equipo");

                }
            }
        }

        private void LimpiarCampos()
        {
            eq.Pais = "";
            eq.LPersonas.Clear();
            eq.Director = "";
            dgvDetalles.Rows.Clear();
            lblTotal.Text = " Total de Jugadores:" + Convert.ToString(eq.LPersonas.Count());
            txtDT.Clear();
            txtPais.Clear();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void CargarPersonas()
        {
            cboPersona.DataSource = serv.ObtenerPersonas();
            cboPersona.DisplayMember = "NombreCompleto";
            cboPersona.ValueMember = "IdPersona";
        }


        private bool validar_Eq()
        {
            if (txtPais.Text == "")
            {
                MessageBox.Show("Debe cargar el pais");
                txtPais.Focus();
                return false;
            }
            else if (txtDT.Text == "")
            {
                MessageBox.Show("Debe cargar el Director Técnico");
                txtDT.Focus();
                return false;
            }else if(eq.LPersonas.Count == 0)
            {
                MessageBox.Show("Debe cargar al menos un jugador");
                dgvDetalles.Focus();
                return false;
            }
            return true;
        }

        private bool validar_Jugador(Jugador a)
        {
            if (eq.search_list(a))
            {
                MessageBox.Show("El jugador ya tiene una posicion cubierta");

                return false;
            }else if(nudCamiseta.Value < 1 || nudCamiseta.Value > 23)
            {
                MessageBox.Show("El numero de camisetas debe estar comprendido entre el 1 y el 23");

                return false;
            }else if (cboPosicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una posicion");

                return false;
            }else if (eq.search_camiseta(Convert.ToInt32(nudCamiseta.Value)))
            {
                MessageBox.Show("El numero de camisetas Esta ocupada ");
                return false;

            }

            return true;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_datagrid(DataGridView dg)
        {
            dg.Rows.Clear();
            for (int i = 0; i < eq.LPersonas.Count; i++)
            {
                dgvDetalles.Rows.Add(new object[] { eq.LPersonas[i].Persona.NombreCompleto, eq.LPersonas[i].Camiseta, eq.LPersonas[i].Posicion });
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            eq.QuitarDetalle(dgvDetalles.CurrentRow.Index);
            dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
            lblTotal.Text = " Total de Jugadores:" + Convert.ToString(eq.LPersonas.Count());

        }
    }
}
