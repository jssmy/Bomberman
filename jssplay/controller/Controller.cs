using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace jssplay.controller
{
    public class Controller
    {
        public String Key { get; set; }
        private String typeKey;
        private int skip;
        private System.Drawing.Bitmap imgPlayer;
        private entity.Presentation present;
        public int opcion;
        entity.Image background = null;
        entity.Image mouse = null;
        
        System.Drawing.Bitmap bmp;
        levels.first one = null;
        public Controller() {
            

            bmp = new System.Drawing.Bitmap(Properties.Resources.main_back);
            background = new entity.Image(0,0,bmp);
            bmp = null;
            bmp = new System.Drawing.Bitmap(Properties.Resources.Ponteiro);
            mouse = new entity.Image(140,105,bmp);
            //present = new entity.Presentation();
            typeKey = "menu";
            opcion = 0;
        }

        public void Draw(System.Drawing.Graphics gr)
        {
            if (typeKey.Equals("menu") || typeKey.Equals("select_player"))
            {
                background.Draw(gr);
                mouse.Draw(gr);
            }
            if (typeKey.Equals("presentation"))
            {
                present.getMessage(gr);
            }
            if(typeKey.Equals("playing")) {
                ///primer nivel
                   one.Draw(gr);
                
            }
            
            
          keyPress();
        }

        private void KeyMenu() {  
            switch(Key){
                case "Up":
                    opcion--;
                    mouse.X-=20;
                    mouse.Y-=30;
                    if (opcion ==-1) {
                        mouse.X+=20*3;
                        mouse.Y+= 30*3;
                        opcion = 2;
                    }
                    

                    break;
                case "Down":
                    opcion++;
                    mouse.X += 20;
                    mouse.Y += 30;
                    if (opcion == 3)
                    {
                        mouse.X = 140;
                        mouse.Y = 105;
                        opcion = 0;
                    }
                    break;
                case "Return":
                    if (opcion == 0) {
                        typeKey = "select_player";
                        background.image = new System.Drawing.Bitmap(Properties.Resources.Players);
                        mouse.X = 160;
                        mouse.Y = 80;
                        opcion = 0;
                    }

                    break;

            }
        
        
        }

        private void SelectPlayer() {
            switch (Key)
            {
                case "Up":
                    opcion--;
                  
                    mouse.Y -= 40;
                    if (opcion == -1)
                    {
                        mouse.Y += 40 * 4;
                        opcion = 3;
                    }
                    break;
                case "Down":
                    opcion++;
                    mouse.Y += 40;
                    if (opcion == 4)
                    {
                        mouse.Y = 80;
                        opcion = 0;
                    }
                    break;
                case "Return":
                    if (opcion == 0) imgPlayer = new System.Drawing.Bitmap(Properties.Resources.BM11);
                    if (opcion == 1) imgPlayer = new System.Drawing.Bitmap(Properties.Resources.BM22);
                    if (opcion == 2) imgPlayer = new System.Drawing.Bitmap(Properties.Resources.BM33);
                    if (opcion == 3) imgPlayer = new System.Drawing.Bitmap(Properties.Resources.BM44);

                    background = null;
                    mouse = null;
                    present = new entity.Presentation();
                        //  one = new levels.first(imgPlayer);

                        
                      //  background.image.Dispose();
                       // mouse.image.Dispose();
                        typeKey = "presentation";

                    break;

            }
        
        
        }


        private void SkipIni() {
            
                present.Key = this.Key;
                if (this.Key.Equals("Return"))
                {
                    skip++;
                    if (skip == 9) {
                        one = new levels.first(imgPlayer);
                        present.Dispose();
                        present = null;
                        this.typeKey = "playing"; 
                    }
                }
        
        }

        
        private void keyPress() { 
            switch(typeKey){
                case "menu" :
                    KeyMenu();
                break;
                case "select_player":
                    SelectPlayer();
                break;
                    
                case "playing":
                    KeyPlay();      
                break;
                case "presentation":
                    SkipIni();
                break;
            
            }
        
        }

        private void KeyPlay() {
            one.Key = this.Key;
        }
    }
}
