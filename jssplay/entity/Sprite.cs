using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public abstract class Sprite:Figure
    {
        protected int col;
        protected int row;
        public Sprite() {
            //Size();
        }

        public override void Size()
        {
            this.Width = this.image.Width / 3;
            this.Height = this.image.Height;
        }

        public override void Draw(System.Drawing.Graphics gr){
            space = new System.Drawing.Rectangle(col*this.Width, row*this.Height, this.Width, this.Height);
            zoom = new System.Drawing.Rectangle(this.X, this.Y, this.Width, this.Height);
            gr.DrawImage(image, zoom, space, System.Drawing.GraphicsUnit.Pixel);

        }

        public abstract void move(int col, int row);


    }
}
