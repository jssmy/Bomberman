using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Image : Figure
    {
        public Image(int x,int y,System.Drawing.Bitmap img) {
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
