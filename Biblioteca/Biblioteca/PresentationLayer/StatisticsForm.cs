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
    public partial class StatisticsForm : Form
    {
        BussinesLayer BLL_Conn;
        public StatisticsForm()
        {
            InitializeComponent();
            BLL_Conn = new BussinesLayer();
            DataView view = BLL_Conn.GetData().DefaultView;
            DataTable distinctValues = new DataTable("distinct");
            distinctValues = view.ToTable(true, "Autor");
            foreach (DataRow row in distinctValues.Rows)
            {
                comboBox4.Items.Add(row["Autor"]);
            }
            distinctValues = view.ToTable(true, "Editura");
            foreach (DataRow row in distinctValues.Rows)
            {
                comboBox3.Items.Add(row["Editura"]);
            }
        }
        //Statistica Autor
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String autor = comboBox4.Text.ToString();
            label22.Text = BLL_Conn.CountAutor(autor);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String editura = comboBox3.Text.ToString();
            label21.Text = BLL_Conn.CountEditura(editura);
        }
    }
}
