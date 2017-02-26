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
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
            
        }
        PictureBox[] snake = new PictureBox[401];
        void init()
        {
            int i;
            for (i = 0; i < 401; i++)
            {
                snake[i] = new PictureBox();
                snake[i].Size = new Size(10, 10);
                snake[i].BackColor = Color.Green;
                if (i != 0)
                    snake[i].Location = new Point(-1, -1);
            }
            snake[0].Location = new Point(100, 100);
            snake[0].BackColor = Color.DarkKhaki;
            marnou();

        }
        void marnou()
        {
            Random rnd = new Random();
            marx=rnd.Next(0,18)*10+10;
            mary=rnd.Next(0,18)*10+10;
            mar.Location = new Point(marx, mary);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox39.Visible = true;
            pictureBox40.Visible = true;
            button7.Enabled = false;
            if (sterg == true)
            {
                sterg = false;
                for (int i = 0; i <= 4; i++)
                {
                    scoruri[i] = 0;
                    nume[i] = "-";
                }
            }
            label2.Visible = true;
            label3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            mar.Visible = true;
            comboBox1.Enabled = false;
            init();
            if (comboBox1.SelectedItem == "Usor")
            {
                timer1.Interval = 100;
                dif = 100;
            }
            else if (comboBox1.SelectedItem == "Mediu")
            {
                timer1.Interval = 75;
                dif = 150;
            }
            else if (comboBox1.SelectedItem == "Greu")
            {
                timer1.Interval = 50;
                dif = 200;
            }
            else
            {
                timer1.Interval = 31;
                dif = 300;
            }
            
            timer1.Enabled = true;
            this.Controls.Add(snake[0]);
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            
        }
        void addscore()
        {
            ScorNou highscore = new ScorNou();
            highscore.ShowDialog();
            gheorghe = highscore.Tag.ToString();
            int i=4,k;
            while (lung * dif > scoruri[i])
            {
                i--;
                if (i == -1)
                    break;
            }
            for (k = 4; k > i + 1; k--)
            {
                scoruri[k] = scoruri[k - 1];
                nume[k] = nume[k - 1];
            }
            scoruri[i + 1] = lung * dif;
            nume[i + 1] = gheorghe;
            
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\scores.sna");
            for (i = 0; i <=4  ; i++)
            {
                sw.WriteLine(nume[i]);
                sw.WriteLine(scoruri[i]);
            }
            sw.Close();
            
            


        }
        void gameover()
        {
            
            timer1.Enabled = false;
            if (lung * dif > scoruri[4] && pereti==1)
                addscore();
            button2.PerformClick();
            button2.Enabled = false;
            button3.Enabled = false;
            mar.Visible = false;
            
        }
        void checkcollision()
        {
            if(pereti==1)
                if (snake[0].Left < 10 || snake[0].Left >= 200 || snake[0].Top < 10 || snake[0].Top >= 190)
                    gameover();
            int a  ;
            for (a = 3; a <=lung; a++) 
            {
                
                if (snake[0].Location == snake[a].Location)
                {
                   
                    gameover();
                    
                }
            }
        }
        int lung=0;
        int ad = 0;
        int dir,xcap=100,ycap=100,marx,mary,dif=100;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            int i;
            if (ad == 1)
            {
                lung++;
                this.Controls.Add(snake[lung]);
                snake[lung].Visible = true;
                snake[lung].Location = snake[lung - 1].Location;
            }

            i = lung - ad;
            while (i > 0)
            {   
                snake[i].Location = snake[i - 1].Location;
                i--;
            }
            switch (dir)
            {
                case 0: xcap += 10; break;
                case 1: ycap += 10; break;
                case 2: xcap -= 10; break;
                case 3: ycap -= 10; break;
            }
            ad = 0;
            if (pereti == 0)
            {
                if (xcap == 0)
                    xcap = 190;
                else if (ycap == 0)
                    ycap = 180;
                else if (xcap == 200)
                    xcap = 10;
                else if (ycap == 190)
                    ycap = 10;
            }
            snake[0].Location = new Point(xcap, ycap);
            i = 0;
            while (i <= lung)
            {
                if (snake[i].Location == mar.Location)
                {
                    ad = 1;
                    marnou();
                    break;
                }
                
                i++;
            }
            checkcollision();
            able = 1;
            label2.Text = "Marime: "+ (lung+1).ToString();
            label3.Text = "Scor: " + ((lung)*dif).ToString();
        }
        int able = 1;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.S && dir != 3 && able==1)
            {
                able = 0;
                dir = 1;
            }
            else if (e.KeyCode == Keys.D && dir != 2 && able == 1)
            {
                dir = 0;
                able = 0;
            }
            else if (e.KeyCode == Keys.W && dir != 1 && able == 1)
            {
                dir = 3;
                able = 0;
            }
            else if (e.KeyCode == Keys.A && dir != 0 && able == 1)
            {
                dir = 2;
                able = 0;
            }
            else if (e.KeyCode==Keys.F)
                button3.PerformClick();
            else if(e.KeyCode==Keys.R)
                button2.PerformClick();
            this.Invalidate();
        }
        public string gheorghe;
        string[] nume = new string[5];
        int[] scoruri = new int[5];
        const string inex="-" + "\n\r"+"0" +"-" + "\n\r"+"0" +"-" + "\n\r"+"0" +"-" + "\n\r"+"0" +"-" + "\n\r"+"0"+"\n\r" ;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\scores.sna"))
            {
                File.Create(Application.StartupPath + "\\scores.sna").Close() ;
                
                File.WriteAllText(Application.StartupPath + "\\scores.sna", "-"+Environment.NewLine+"0"+Environment.NewLine+"-"+Environment.NewLine+"0"+Environment.NewLine+"-"+Environment.NewLine+"0"+Environment.NewLine+"-"+Environment.NewLine+"0"+Environment.NewLine+"-"+Environment.NewLine+"0"+Environment.NewLine);
                
            }
            int k=0;
            //this.BackColor = Color.Maroon;
            this.TransparencyKey = Color.Maroon;
            StreamReader sr=new StreamReader(Application.StartupPath +"\\scores.sna");
            while (!sr.EndOfStream)
            {
                if (k % 2 == 0)
                    nume[k / 2] = sr.ReadLine();
                else scoruri[k / 2] =Convert.ToInt32(sr.ReadLine());
                k++;
            }
            sr.Close();
            
        }
        void newgame()
        {
            lung = 0;
            snake[0].Location = new Point(100, 100);
            timer1.Enabled = false;
            ad = 0;
            marnou();
            xcap = 100; ycap = 100;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            mar.Visible = false;
            pictureBox39.Visible = false;
            pictureBox40.Visible = false;
            button7.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            int i;
            for (i = 0; i <= lung; i++)
            {
                this.Controls.Remove(snake[i]);
            }
            newgame();
            comboBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
                timer1.Enabled = true;
            else timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form form4=new Ajutor();
            form4.ShowDialog();

        }
        string mesajscoruri;
        private void button5_Click(object sender, EventArgs e)
        {
            Tabela afis = new Tabela();
            afis.ShowDialog();
            if (afis.Tag == "sterge")
                sterg = true ;
                   
        }
        bool sterg = false;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int pereti = 1;
        private void button7_Click(object sender, EventArgs e)
        {
            if (pereti == 0)
            {
                pereti = 1;
                button7.Text = "Fara pereti";
            }
            else
            {
                pereti = 0;
                button7.Text = "Cu pereti";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "Mod transparent")
            {
                button8.Text = "Mod opac";
                this.BackColor = Color.Maroon;
            }
            else
            {
                this.BackColor = Color.White;
                button8.Text = "Mod transparent";
            }
        }
    }
}
