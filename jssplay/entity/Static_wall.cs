using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Static_wall: Figure
    {
        int i;
        int j;

        public Static_wall(int x, int y,int i, int j, System.Drawing.Bitmap img)
        {
            this.i = i;
            this.j = j;
            
            this.X = x;
            this.Y = y;
            this.image = img;
            this.Size();
        }

        public override void Size()
        {
            this.Width = this.image.Width;
            this.Height = this.image.Height;
        }

    }

    




}
