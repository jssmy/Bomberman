using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Enemy:Sprite
    {
        public String Key;
        public int varX { get; set; }
        public int varY { get; set; }
        public bool state { get; set; }
        private int div_row;
        private int div_col;
        public Enemy(int x, int y,int div_row, int div_col,System.Drawing.Bitmap bmp)
        {
            this.X = x;
            this.Y = y;
            this.image =  bmp;
            this.state = false;
            this.div_col = div_col;
            this.div_row = div_row;
            this.Size();
        }
        public override void Size()
        {
            this.Width = this.image.Width / this.div_col;
            this.Height = this.image.Height / this.div_row;
        }
        public override void move(int col, int row)
        {
            throw new NotImplementedException();
        }

        private void KeyMove()
        {
            switch (Key)
            {
                case "Up":
                    this.varY = -5;
                    this.varX = 0;
                    this.row = 1;
                    break;
                case "Down":
                    this.varY = 5;
                    this.varX = 0;
                    this.row = 0;
                    break;
                case "Left":
                    this.varX = -5;
                    this.varY = 0;
                    this.row = 3;
                    break;
                case "Right":
                    this.varX = 5;
                    this.varY = 0;
                    this.row = 2;
                    break;
                default:
                    this.varX = this.varY = 0;
                    
                    break;
            }

            ///
            this.col++;
            if (this.col >= 3) this.col = 0;
           this.X += this.varX;
           this.Y += this.varY;

        }

        public void move(System.Drawing.Graphics gr) {
            this.Draw(gr);
            this.KeyMove();
           
        
        }
        

        private void Died()
        {

        }





    }
}
