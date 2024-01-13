using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlane_RVP_Yurl
{
    internal class Pregrad
    {
        Random random = new Random();
        public int width;
        public int height;
        public int x;
        public int y;
        public int speed;
        

        public Pregrad()
        {
            this.width = 20;
            this.height = 20;
            this.y = 0;
            this.x = 20 * random.Next(0, 18);
            this.speed = 20;
        }
        public void MovePregrad()
        {
            this.y += speed;
        }
    }
}
