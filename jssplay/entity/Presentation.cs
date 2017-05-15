using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    
    public class Presentation
    {
        private int opcion;
        public String Key;
        private Image backround;
        private String Letter1;
        private String Letter2;
        private String Letter3;
        private System.Drawing.Font font;
        
        private System.Drawing.SolidBrush brush;
        private System.Drawing.Point point;
        public Presentation()
        {
            backround = new Image(0,0,Properties.Resources.ini1);
            Letter1 = "La humanidad se encuentra en peligro por tipos malos";
            Letter2 = "que intentan controlar el planeta. Tenemos la misiòn";
            Letter3 = "de impedir que ellos logren su objetivo.";
            font = new System.Drawing.Font("Arial",12);
            brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            point = new System.Drawing.Point(40,200);
            Key = "-";
            
        }

        public void getMessage(System.Drawing.Graphics gr)
        {
            backround.Draw(gr);
            MessageShow(gr);
            
            if (this.Key.Equals("Return"))
            {
                opcion++;
                if (opcion == 1)
                {
                    secondMessage();
                }
                if (opcion == 2)
                {
                    thirdMessage();
                }
                if (opcion == 3)
                {
                    fourthdMessage();
                }
                if (opcion == 4)
                {
                    fivethdMessage();
                }
                if (opcion == 5)
                {
                    sixthMessage();
                }
                if (opcion == 6)
                {
                    sevethMessage();
                }
                if (opcion == 7)
                {
                    eightMessage();
                }

                    
            }
            
            
        }

        private void MessageShow(System.Drawing.Graphics gr) {
            point = new System.Drawing.Point(point.X, 205);
            gr.DrawString(Letter1, font, brush, point);
            point = new System.Drawing.Point(point.X, 225);
            gr.DrawString(Letter2, font, brush, point);
            point = new System.Drawing.Point(point.X, 245);
            gr.DrawString(Letter3, font, brush, point);
        
        }
        private void secondMessage() {
            backround.image = Properties.Resources.ini4;
            Letter1 = "Claro que confìo en tus habilidades de batalla.";
            Letter2 = "Recoge los items para adquirir nuevas habilidades.";
            Letter3 = "";
        }
        private void thirdMessage()
        {
            backround.image = Properties.Resources.ini7;
            Letter1 = "";
            Letter2 = "";
            Letter3 = "";
        }

        private void fourthdMessage()
        {
            backround.image = Properties.Resources.ini8;
            Letter1 = "";
            Letter2 = "";
            Letter3 = "";
            
        }

        private void fivethdMessage() {
            backround.image = Properties.Resources.ini6;
            Letter1 = "No es posible!";
            Letter2 = "Estàn armando su ejèrcito de villanos!";
            Letter3 = "";
        }

        private void sixthMessage()
        {
            backround.image = Properties.Resources.ini11;
            Letter1 = "No te olvides de controlar el tiempo.";
            Letter2 = "Cada nivel se pone dificil. Tienes que recoger items ";
            Letter3 = "para poder tener ventaja";
        }

        private void  sevethMessage()
        {
            backround.image = Properties.Resources.ini10;
            Letter1 = "No!.";
            Letter2 = "Me atacan!";
            Letter3 = "Aiuda! :V";
        }

        private void eightMessage()
        {
            backround.image = Properties.Resources.ini9;
            Letter1 = "";
            Letter2 = "";
            Letter3 = "";
        }

        public void Dispose()
        {
            this.Key = String.Empty;
            this.Letter1 = String.Empty;
            this.Letter2 = String.Empty;
            this.Letter3 = String.Empty;
            this.backround = null;



        }
        


    }



}
