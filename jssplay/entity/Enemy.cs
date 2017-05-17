using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Enemy:Sprite
    {
        public int varX { get; set; }
        public int varY { get; set; }


        public bool state { get; set; }
        public Enemy(int x, int y,System.Drawing.Bitmap bmp)
        {
            this.X = x;
            this.Y = y;
            this.image =  bmp;
            this.state = false;
            this.Size();
        }
        public override void Size()
        {
            
        }
        public override void move(int col, int row)
        {
            throw new NotImplementedException();
        }

        public void move() { }
        

        private void Died()
        {

        }





    }
}
