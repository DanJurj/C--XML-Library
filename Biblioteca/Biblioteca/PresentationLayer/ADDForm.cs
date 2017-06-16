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
    public partial class ADDForm : Form
    {
        BussinesLayer BLL_Conn;
        public ADDForm()
        {
            InitializeComponent();
            BLL_Conn = new BussinesLayer();
        }

        //Adaugare Carte
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text=="" || textBox4.Text=="" || textBox16.Text=="" || textBox14.Text=="" || textBox5.Text=="" || textBox6.Text=="" || textBox7.Text=="")
            {
                MessageBox.Show("Va rugam completati toate casutele!");
                return;
            }
            String titlu = textBox2.Text.ToString();
            String autor = textBox3.Text.ToString();
            String editura = textBox4.Text.ToString();
            int anE = int.Parse(textBox16.Text.ToString());
            int anA = int.Parse(textBox14.Text.ToString());
            String limba = textBox5.Text.ToString();
            String categorie = textBox6.Text.ToString();
            int pret = int.Parse(textBox7.Text.ToString());
            if(BLL_Conn.InsertData(titlu, autor, editura, anE, anA, limba, categorie, pret))
            {
                MessageBox.Show("Cartea introdusa a fost adaugata cu succes in biblioteca noastra! Va multumim!");
            }
            else
            {
                MessageBox.Show("A aparut o eroare la adaugarea cartii! Va rugam reincercati!");
            }
        }
    }
}
