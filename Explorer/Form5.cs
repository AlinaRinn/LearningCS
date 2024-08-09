using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskReader
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public float result, check, rate;
        public int answer, lose;

        private void button_rock_Click(object sender, EventArgs e)
        {
            answer = 0;
            Thinker();
        }

        private void button_paper_Click(object sender, EventArgs e)
        {
            answer = 1;
            Thinker();
        }

        private void button_scissors_Click(object sender, EventArgs e)
        {
            answer = 2;
            Thinker();
        }

        private void Thinker()
        {
            check++;
            var rand = new Random();
            int companswer = rand.Next(0, 3);           
            if (companswer == 0)
            {
                label_ans.Text = "Rock";
            }
            else if (companswer == 1)
            {
                label_ans.Text = "Paper";
            }
            else if (companswer == 2)
            {
                label_ans.Text = "Scissors";
            }
            if (companswer == answer)
            {
                label_winlose.Text = "Draw";
                label_winlose.ForeColor = Color.Orange;
                listView_log.Items.Add(label_winlose.Text);
                check--;
            }
            else if ((companswer == 0) && (answer == 2))
            {
                label_winlose.Text = "Loser";
                label_winlose.ForeColor = Color.Red;
                listView_log.Items.Add(label_winlose.Text);
                lose++;
            }
            else if ((companswer == 1) && (answer == 0))
            {
                label_winlose.Text = "Loser";
                label_winlose.ForeColor = Color.Red;
                listView_log.Items.Add(label_winlose.Text);
                lose++;
            }
            else if ((companswer == 2) && (answer == 1))
            {
                label_winlose.Text = "Loser";
                label_winlose.ForeColor = Color.Red;
                listView_log.Items.Add(label_winlose.Text);
                lose++;
            }
            else
            {
                label_winlose.Text = "Winner";
                label_winlose.ForeColor = Color.Green;
                listView_log.Items.Add(label_winlose.Text);
                rate++;
            }
            if (rate != 0)
            {
                result = rate / check * 100;
            }
            label_winrate.Text = result.ToString("#.##") + "%";
        }
    }
}
