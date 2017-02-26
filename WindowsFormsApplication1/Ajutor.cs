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
    public partial class Ajutor : Form
    {
        public Ajutor()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Olive;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
