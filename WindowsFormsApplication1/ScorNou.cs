using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ScorNou : Form
    {
        public ScorNou()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Tag = textBox1.Text;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Olive;
            //this.TransparencyKey = Color.Maroon;
        }
    }
}
