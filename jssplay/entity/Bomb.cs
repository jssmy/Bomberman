using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Bomb:Sprite
    {
        
        private Flame flame;
        public Boolean xplote;
        //private Boolean state;
        private int div;
        private int time;
        public List<int> posMatrix{set;get;}
        public Bomb(int x, int y,int div ,int [,] matrix,System.Drawing.Bitmap img)
        {
            this.X = x;
            this.Y = y;
            this.image = img;
            
            this.div = div;
            Size();
            flame = new Flame(this.X, this.Y,2,matrix);
            matrix = null;
            posMatrix = new List<int>();
        }

        public override void Size()
        {
            this.Width = this.image.Width / div;
            this.Height = this.image.Height;
        }

        public override void move(int col, int row)
        {
            
        }
        public void move(System.Drawing.Graphics gr)
        {
            

            if (time == 40)
            {
                
                ///Died(gr);
                flame.GeTSizeLLama();
                xplote = true;
            }
            else
            {
                Draw(gr);
                time++;
                this.col++;
                if (this.col > div - 1) this.col = 0;

            }
            if (xplote)
            {
                Died(gr);
            }
            
        }
        public void Died(System.Drawing.Graphics gr)
        {
            flame.Draw(gr);
            posMatrix= flame.posMatrixx();
        }
        public List<System.Drawing.Point> posFlame()
        {
            return flame.posFlame;
        }

        public void Dispose()
        {
            flame.Dispose();
            flame = null;
            //this.image.Dispose();
        }

    }

}
