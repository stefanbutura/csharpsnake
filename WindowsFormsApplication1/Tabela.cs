using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Tabela : Form
    {
        public Tabela()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Application.StartupPath + "\\scores.sna");
            this.BackColor = Color.Olive;
            label1.Text = sr.ReadLine();
            label6.Text = sr.ReadLine();
            label2.Text = sr.ReadLine();
            label7.Text = sr.ReadLine();
            label3.Text = sr.ReadLine();
            label8.Text = sr.ReadLine();
            label4.Text = sr.ReadLine();
            label9.Text = sr.ReadLine();
            label5.Text = sr.ReadLine();
            label10.Text = sr.ReadLine();
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Application.StartupPath + "\\scores.sna", "-" + Environment.NewLine + "0" + Environment.NewLine + "-" + Environment.NewLine + "0" + Environment.NewLine + "-" + Environment.NewLine + "0" + Environment.NewLine + "-" + Environment.NewLine + "0" + Environment.NewLine + "-" + Environment.NewLine + "0" + Environment.NewLine);
            this.Tag = "sterge";
            label1.Text = "-";
            label6.Text = "0";
            label2.Text = "-";
            label7.Text = "0";
            label3.Text = "-";
            label8.Text = "0";
            label4.Text = "-";
            label9.Text = "0";
            label5.Text = "-";
            label10.Text = "0";
        }
    }
}
