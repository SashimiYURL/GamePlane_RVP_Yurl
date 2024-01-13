using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlane_RVP_Yurl
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Random random = new Random();
        bool generation=true;
        List<Pregrad> pregrads = new List<Pregrad>();
        Player player=new Player();
        public Form1()
        {
            
            InitializeComponent();
            //MessageBox.Show(panel.ClientSize.Width.ToString());
            bmp = new Bitmap(panel.ClientSize.Width, panel.ClientSize.Height);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            bmp=new Bitmap(panel.ClientSize.Width, panel.ClientSize.Height);
            Graphics graphics = Graphics.FromImage(bmp); 
            SolidBrush sbrush=new SolidBrush(Color.DarkGray);
            foreach(Pregrad pregr in pregrads)
            {
                graphics.FillRectangle(sbrush, pregr.x, pregr.y, pregr.width, pregr.height);
            }
            graphics.FillRectangle(player.brush, player.x, player.y, player.width, player.height);

            e.Graphics.DrawImageUnscaled(bmp, Point.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (generation)
            {
                GeneratedLevel();
            }
            foreach(Pregrad pregrad in pregrads)
            {
                if ((pregrad.y + 20) == player.y && pregrad.x == player.x)
                {
                    GameOver();
                    panel.Invalidate();
                    return;
                }
                else
                {
                    pregrad.MovePregrad();
                    if (pregrad.y >= panel.ClientSize.Height)
                    {
                        pregrad.y = 0;
                        pregrad.x = 20*random.Next(1,25);
                        generation = false;

                    }
                }
            }
            panel.Invalidate();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public void GeneratedLevel()
        {
            for(int i = 0; i <=3; i++)
            {
                Pregrad newpregrad=new Pregrad();
                pregrads.Add(newpregrad);
            }
        }
        public void GameOver()
        {
            timer1.Stop();
            MessageBox.Show("Вы проиграли!Игра закончена!");
            generation = true;
            player = new Player();
            pregrads.Clear();
            panel.Invalidate();
        }

        public bool PlayerCrash(int y,int x)
        {
            foreach(Pregrad pregrad in pregrads)
            {
                if (pregrad.y == y && pregrad.x == x) return true;
            }
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.A && player.x - 20 >= 0)
            {
                if (!PlayerCrash(player.y, player.x - 20)) { player.x -= 20; }
            }
            if (e.KeyCode == Keys.D && player.x + 20 <= panel.ClientSize.Width-20)
            {
                if (!PlayerCrash(player.y, player.x + 20)) { player.x += 20; }
            }
            if (e.KeyCode == Keys.W && player.y - 20>=0)
            {
                if (!PlayerCrash(player.y - 20, player.x)) { player.y -= 20; }
                else GameOver();
            }
            if (e.KeyCode == Keys.S && player.y +20 <=panel.ClientSize.Height-20)
            {
                if (!PlayerCrash(player.y + 20, player.x)) { player.y += 20; }
                else GameOver();
            }
            panel.Invalidate();
        }
    }
}
