using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class ModifyForm : Form
    {
        BussinesLayer BLL_Conn;
        public ModifyForm()
        {
            InitializeComponent();
            BLL_Conn = new BussinesLayer();
        }

        //Casute Modificare
        private void button4_Click(object sender, EventArgs e)
        {
            String titlu = textBox13.Text.ToString();
            DataRow row = BLL_Conn.SelectData(titlu);
            textBox12.Text = row["Autor"].ToString();
            textBox11.Text = row["Editura"].ToString();
            textBox15.Text = row["Anul Editurii"].ToString();
            textBox10.Text = row["Limba"].ToString();
            textBox9.Text = row["Categorie"].ToString();
            textBox8.Text = row["Pret"].ToString();
        }

        //Salvare Modificari
        private void button3_Click(object sender, EventArgs e)
        {
            String titlu = textBox13.Text.ToString();
            String autor = textBox12.Text.ToString();
            String editura = textBox11.Text.ToString();
            int anE = int.Parse(textBox15.Text.ToString());
            String limba = textBox10.Text.ToString();
            String categorie = textBox9.Text.ToString();
            int pret = int.Parse(textBox8.Text.ToString());
            if (BLL_Conn.UpdateCarte(titlu, autor, editura, anE, limba, categorie, pret))
                MessageBox.Show("Modificarile au fost inregistrate cu succes!");
        }
    }
}
