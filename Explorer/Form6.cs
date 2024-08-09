using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIO;

namespace DiskReader
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Class1 G = new Class1();

            label1.Text = G.surname.ToString();
            label2.Text = G.name.ToString();
            label3.Text = G.othername.ToString();
            label4.Text = G.group.ToString();
            label5.Text = G.project.ToString();
            label6.Text = G.numberlab.ToString();
        }
    }
}
