using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlane_RVP_Yurl
{
    internal class Player
    {
        Random random = new Random();
        public int width;
        public int height;
        public int x;
        public int y;
        public SolidBrush brush=new SolidBrush(Color.Red);

        public Player()
        {
            this.width = 20;
            this.height = 20;
            this.y = 300;
            this.x=20*random.Next(1,18);
        } 
    }
    
}
