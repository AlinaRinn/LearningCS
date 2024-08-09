using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DiskReader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            Label tab1 = new Label();
            tableLayoutPanel1.Controls.Add(tab1, 0, 0);
            tab1.Dock = DockStyle.Fill;
            tab1.Text = "Буква тома: ";

            Label tab2 = new Label();
            tableLayoutPanel1.Controls.Add(tab2, 0, 1);
            tab2.Dock = DockStyle.Fill;
            tab2.Text = "Тип тома: ";

            Label tab3 = new Label();
            tableLayoutPanel1.Controls.Add(tab3, 0, 2);
            tab3.Dock = DockStyle.Fill;
            tab3.Text = "Метка тома: ";

            Label tab4 = new Label();
            tableLayoutPanel1.Controls.Add(tab4, 0, 3);
            tab4.Dock = DockStyle.Fill;
            tab4.Text = "Файловая система: ";

            Label tab5 = new Label();
            tableLayoutPanel1.Controls.Add(tab5, 0, 4);
            tab5.Dock = DockStyle.Fill;
            tab5.Text = "Доступно: ";

            Label tab6 = new Label();
            tableLayoutPanel1.Controls.Add(tab6, 0, 5);
            tab6.Dock = DockStyle.Fill;
            tab6.Text = "Общий объем: ";

            Label tab7 = new Label();
            tableLayoutPanel1.Controls.Add(tab7, 0, 6);
            tab7.Dock = DockStyle.Fill;
            tab7.Text = "Занято: ";

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            int i = 1;

            foreach (DriveInfo d in allDrives) {
                Label lbl1 = new Label();
                tableLayoutPanel1.Controls.Add(lbl1, i, 0);
                lbl1.Dock = DockStyle.Fill;
                lbl1.Text = d.Name;

                Label lbl2 = new Label();
                tableLayoutPanel1.Controls.Add(lbl2, i, 1);
                lbl2.Dock = DockStyle.Fill;
                lbl2.Text = d.DriveType.ToString();

                if (d.IsReady == true)
                {
                    Label lbl3 = new Label();
                    tableLayoutPanel1.Controls.Add(lbl3, i, 2);
                    lbl3.Dock = DockStyle.Fill;
                    lbl3.Text = d.VolumeLabel;
                    if (d.VolumeLabel == "")
                    {
                        lbl3.Text = "Unknown";
                    }

                    Label lbl4 = new Label();
                    tableLayoutPanel1.Controls.Add(lbl4, i, 3);
                    lbl4.Dock = DockStyle.Fill;
                    lbl4.Text = d.DriveFormat;


                    Label lbl5 = new Label();
                    tableLayoutPanel1.Controls.Add(lbl5, i, 4);
                    long tmp0 = (d.AvailableFreeSpace / 1024 / 1024 / 1024);
                    lbl5.Dock = DockStyle.Fill;
                    lbl5.Text = tmp0.ToString() + " GB";

                    Label lbl6 = new Label();
                    tableLayoutPanel1.Controls.Add(lbl6, i, 5);
                    long tmp1 = (d.TotalSize / 1024 / 1024 / 1024);
                    lbl6.Dock = DockStyle.Fill;
                    lbl6.Text = tmp1.ToString() + " GB";

                    Label lbl7 = new Label();
                    tableLayoutPanel1.Controls.Add(lbl7, i, 6);
                    long tmp = tmp1 - tmp0;
                    lbl7.Dock = DockStyle.Fill;
                    lbl7.Text = tmp.ToString() + " GB";

                    i++; tmp0 = 0; tmp1 = 0; tmp = 0;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e) 
        {
            tableLayoutPanel1.Controls.Clear();
            Form1_Load(sender, e);
        }
            
    }
}
    
