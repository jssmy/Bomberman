using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public abstract class Figure
    {
        public int i;
        public int j;

        public int X{set;get;}
        public int Y{set;get;}
        public int Width{set;get;}
        public int Height{set;get;}
        protected Rectangle space;
        protected Rectangle zoom;
        public Bitmap image;
        public Figure() {
            
        }
        public abstract void Size();
        public virtual void Draw(Graphics gr) {
            
            space = new System.Drawing.Rectangle(0, 0, this.Width, this.Height);
            zoom = new System.Drawing.Rectangle(this.X, this.Y, this.Width, this.Height);
            gr.DrawImage(image, zoom, space, GraphicsUnit.Pixel);
            
        }



       
            

    }
}
