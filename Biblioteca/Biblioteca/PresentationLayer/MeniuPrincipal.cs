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
    public partial class MeniuPrincipal : Form
    {
        public MeniuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BooksForm main_form = new BooksForm();
            main_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADDForm main_form = new ADDForm();
            main_form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModifyForm main_form = new ModifyForm();
            main_form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StatisticsForm main_form = new StatisticsForm();
            main_form.Show();
        }
    }
}
