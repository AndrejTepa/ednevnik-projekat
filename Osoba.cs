using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace ednevnik_projekat
{
    public partial class Osoba : Form
    {
        int broj_sloga = 0;
        DataTable tabela;
        public Osoba()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            SqlConnection veza = konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from osoba;", veza);
            tabela = new DataTable();
            adapter.Fill(tabela);
        }
        private void LoadTxt()
        {
            if (tabela.Rows.Count == -1)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
            else
            {
                textBox1.Text = tabela.Rows[broj_sloga]["id"].ToString();
                textBox2.Text = tabela.Rows[broj_sloga]["ime"].ToString();
                textBox3.Text = tabela.Rows[broj_sloga]["prezime"].ToString();
                textBox4.Text = tabela.Rows[broj_sloga]["adresa"].ToString();
                textBox5.Text = tabela.Rows[broj_sloga]["jmbg"].ToString();
                textBox6.Text = tabela.Rows[broj_sloga]["email"].ToString();
                textBox7.Text = tabela.Rows[broj_sloga]["pass"].ToString();
                textBox8.Text = tabela.Rows[broj_sloga]["uloga"].ToString();
            }
            if (broj_sloga == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            if (broj_sloga == tabela.Rows.Count-1)
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
            else
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
        }
        private void Osoba_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            LoadData();
            LoadTxt();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            LoadTxt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            LoadTxt();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            LoadTxt();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            broj_sloga = tabela.Rows.Count-1;
            LoadTxt();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection veza = konekcija.Connect();
            veza.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = veza;
            cmd.CommandText = "Insert into  osoba values ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "')";
            cmd.ExecuteNonQuery();
            LoadData();
            LoadTxt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection veza = konekcija.Connect();
            veza.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = veza;
            cmd.CommandText = "Update osoba set ime='" + textBox2.Text + "', prezime='" + textBox3.Text + "', adresa='" + textBox4.Text + "', jmbg= '" + textBox5.Text + "', email ='" +textBox6.Text+ "', pass= '" + textBox7.Text + "', uloga= '" + Convert.ToInt32(this.textBox8.Text) + "' where id = '"+ Convert.ToInt32(this.textBox1.Text) + "'"; 
            cmd.ExecuteNonQuery();
            veza.Close();
            LoadData();
            LoadTxt();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection veza = konekcija.Connect();
            veza.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = veza;
            cmd.CommandText = "Delete from osoba where id ='" + Convert.ToInt32(this.textBox1.Text) + "'";
            cmd.ExecuteNonQuery();
            veza.Close();
            LoadData();
            LoadTxt();
        }
    }
}
