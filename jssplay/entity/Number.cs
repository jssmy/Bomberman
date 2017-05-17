using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Number:Sprite
    {
        private int div;
        public Number(int x, int y, int div, System.Drawing.Bitmap img ) {
            this.X = x;
            this.Y = y;
            this.image = img;
            this.div = div;
            this.Size();
            
        }
        public override void Size(){
            this.Width = this.image.Width / div;
            this.Height = this.image.Height;
        }

        public override void move(int col, int row){
            this.col = col;
            this.row = row;
                
        }
    }
}
