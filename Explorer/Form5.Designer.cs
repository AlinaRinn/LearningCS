
namespace DiskReader
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_rock = new System.Windows.Forms.Button();
            this.button_paper = new System.Windows.Forms.Button();
            this.button_scissors = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_ans = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_winlose = new System.Windows.Forms.Label();
            this.listView_log = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_winrate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_rock
            // 
            this.button_rock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_rock.Location = new System.Drawing.Point(139, 12);
            this.button_rock.Name = "button_rock";
            this.button_rock.Size = new System.Drawing.Size(183, 68);
            this.button_rock.TabIndex = 0;
            this.button_rock.Text = "Rock";
            this.button_rock.UseVisualStyleBackColor = true;
            this.button_rock.Click += new System.EventHandler(this.button_rock_Click);
            // 
            // button_paper
            // 
            this.button_paper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_paper.Location = new System.Drawing.Point(328, 12);
            this.button_paper.Name = "button_paper";
            this.button_paper.Size = new System.Drawing.Size(174, 68);
            this.button_paper.TabIndex = 1;
            this.button_paper.Text = "Paper";
            this.button_paper.UseVisualStyleBackColor = true;
            this.button_paper.Click += new System.EventHandler(this.button_paper_Click);
            // 
            // button_scissors
            // 
            this.button_scissors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_scissors.Location = new System.Drawing.Point(508, 12);
            this.button_scissors.Name = "button_scissors";
            this.button_scissors.Size = new System.Drawing.Size(162, 68);
            this.button_scissors.TabIndex = 2;
            this.button_scissors.Text = "Scissors";
            this.button_scissors.UseVisualStyleBackColor = true;
            this.button_scissors.Click += new System.EventHandler(this.button_scissors_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label_ans);
            this.panel1.Location = new System.Drawing.Point(139, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 111);
            this.panel1.TabIndex = 3;
            // 
            // label_ans
            // 
            this.label_ans.AutoSize = true;
            this.label_ans.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ans.ForeColor = System.Drawing.Color.Black;
            this.label_ans.Location = new System.Drawing.Point(225, 35);
            this.label_ans.Name = "label_ans";
            this.label_ans.Size = new System.Drawing.Size(47, 37);
            this.label_ans.TabIndex = 0;
            this.label_ans.Text = "...";
            this.label_ans.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(324, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // label_winlose
            // 
            this.label_winlose.AutoSize = true;
            this.label_winlose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_winlose.ForeColor = System.Drawing.Color.Red;
            this.label_winlose.Location = new System.Drawing.Point(390, 277);
            this.label_winlose.Name = "label_winlose";
            this.label_winlose.Size = new System.Drawing.Size(21, 20);
            this.label_winlose.TabIndex = 5;
            this.label_winlose.Text = "...";
            // 
            // listView_log
            // 
            this.listView_log.HideSelection = false;
            this.listView_log.Location = new System.Drawing.Point(12, 12);
            this.listView_log.Name = "listView_log";
            this.listView_log.Size = new System.Drawing.Size(121, 242);
            this.listView_log.TabIndex = 6;
            this.listView_log.UseCompatibleStateImageBehavior = false;
            this.listView_log.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(311, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Opponent select:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Winrate:";
            // 
            // label_winrate
            // 
            this.label_winrate.AutoSize = true;
            this.label_winrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_winrate.Location = new System.Drawing.Point(86, 277);
            this.label_winrate.Name = "label_winrate";
            this.label_winrate.Size = new System.Drawing.Size(76, 20);
            this.label_winrate.TabIndex = 9;
            this.label_winrate.Text = "Unknown";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 312);
            this.Controls.Add(this.label_winrate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView_log);
            this.Controls.Add(this.label_winlose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_scissors);
            this.Controls.Add(this.button_paper);
            this.Controls.Add(this.button_rock);
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Rock Paper Scissors";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_rock;
        private System.Windows.Forms.Button button_paper;
        private System.Windows.Forms.Button button_scissors;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_winlose;
        private System.Windows.Forms.ListView listView_log;
        private System.Windows.Forms.Label label_ans;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_winrate;
    }
}