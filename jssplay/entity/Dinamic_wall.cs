using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Dinamic_wall:Sprite
    {
       // public Item item;
        public bool state;
        //public int i;
        //public int j;
        public Dinamic_wall(int x, int y, int i, int j , System.Drawing.Bitmap img)
        {
            
            this.X = x;
            this.Y = y;
            this.image = img;
            this.state = false;
            this.Size();
            this.i = i;
            this.j = j;
            
        }

        public override void Size()
        {
            this.Width = this.image.Width / 3;
            this.Height = this.image.Height;
        }
                
        public override void move(int col, int row)
        {
            

        }

        public void move(System.Drawing.Graphics gr)
        {
            Draw(gr);
            this.row++;
            if (this.row > 1) this.row = 0;
        }

        public bool verifColision(int i, int j) {
            if (this.i == i && this.j == j)  return true;

            return false;
        
        }

        public bool Die(){
            this.col++;
            if (this.col > 3) return true;

            return false;
        
        }

        
    }
}
