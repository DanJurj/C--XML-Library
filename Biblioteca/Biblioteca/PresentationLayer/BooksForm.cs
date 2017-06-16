using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Biblioteca
{
    public partial class BooksForm : Form
    {
        BussinesLayer BLL_Conn;
        public BooksForm()
        {
            InitializeComponent();
            BLL_Conn = new BussinesLayer();
            dataGridView1.DataSource = BLL_Conn.GetData();
        }

        //cautarea
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            String text = textBox1.Text.ToString();
            String criteriu = comboBox1.Text.ToString();
            DataView filter = BLL_Conn.SearchData(criteriu, text);
            dataGridView1.DataSource = filter;
        }

        //ordonarea
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selected = comboBox2.Text.ToString();
            DataView ordered = BLL_Conn.OrderData(selected);
            dataGridView1.DataSource = ordered;
        }

        //Stergere Carte
        private void button1_Click_1(object sender, EventArgs e)
        {
            string titlu = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            BLL_Conn.DeteleData(titlu);
            dataGridView1.DataSource = BLL_Conn.GetData();
        }
    }
}
