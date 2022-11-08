using System.Data.SqlClient;


namespace ABMPersonas
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=fedet\sqlexpress;Initial Catalog=TUPPI;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;

        public Form1()
        {
            InitializeComponent();
            
        }

        public Form1(int inicializado)
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            habilitar(true);
        }

        private void habilitar(bool a)
        {
            button1.Enabled = a;
            button2.Enabled = a;
            button3.Enabled = a;
            button4.Enabled = !a;
            button5.Enabled = !a;
            comboBox1.Enabled = !a;
            comboBox2.Enabled = !a;
            textBox1.Enabled = !a;
            textBox2.Enabled = !a;
            textBox3.Enabled = !a;
            radioButton1.Enabled = !a;
            radioButton2.Enabled = !a;
            button6.Enabled = a;
            checkBox1.Enabled = !a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(false);
        }

        private void limpiar()
        {
            
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Enabled = false;
            checkBox1.Checked = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Seguro que quiere cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                limpiar();
                habilitar(true);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            habilitar(false);
        }

        private void sin_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarcampos(sin_usuarios.SelectedIndex);
        }

        private void cargarcampos(int index)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}