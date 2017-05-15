using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 namespace jssplay.entity
{
    public class Player:Sprite
    {
        public String keyPress;

        private List<Bomb> bmbs;
        private int[,] map;
        private Bomb bmb;
        private System.Drawing.Bitmap imgBomb;
        
        private int live;
        private int score;
        public int varX{get; set;}
        public int varY { get; set; }
        private int posX = 0;
        private int posY = 0;
        private int psValue; /// es la variable que restringe pasar sobre la pared
        private int auxX;
        private int auxY;


        public Player(int x, int y, System.Drawing.Bitmap img, int [,] map) {
            this.X = x;
            this.Y = y;
            this.image = img;
            this.Size();
            this.live = 3;
            this.score = 0;
            keyPress = "-";
            bmbs = new List<Bomb>();
            imgBomb = new System.Drawing.Bitmap(Properties.Resources.B1);
            this.map = map;
            this.psValue = 2;
            

        }

        public override void Size()
        {
            this.Width = this.image.Width / 4;
            this.Height = this.image.Height / 5;

        }
        
        public override void move(int b, int a){}
        
        public void move(String keypss, System.Drawing.Graphics gr)
        {

            Draw(gr);
            DrawBomb(gr);
            this.keyPress = keypss;
            KeyMove();


        }
        

        private void KeyMove()
        {

            int donw_i = ((Y - 36) + this.Height + 10) / 32;
            int down_up_j = ((X - 42)) / 33;
            int down_up_jj = ((X - 42) + Width - 3) / 33;
            int up_i = ((Y - 36) + this.Height / 2) / 32;
            int left_r_i = ((Y - 36) + this.Height) / 32;
            int left_j = ((X - 42) - 5) / 33;
            int right_j = ((X - 42) + this.Width + 8) / 33;
            
            switch (keyPress)
            {
                    
                case "Left":
                    varX = -5;
                    varY = 0;
                    posX = X;
                    if ((X <= 45) || map[left_r_i, left_j] == 1 || map[left_r_i, left_j] == psValue || map[left_r_i, left_j] == 4) { varX = 0; X = posX; }
                    this.row = 3;
                    break;
                case "Right":
                    varX = 5;
                    varY = 0;
                    posX = X;
                    if ((X >= 405) || map[left_r_i, right_j] == 1 || map[left_r_i, right_j] == psValue || map[left_r_i, right_j] == 4 ) { varX = 0; X = posX; }
                    this.row = 2;
                    break;
                case "Up":
                    varY=-5;
                    varX = 0;
                    posY = Y;
                    if (Y<22 || map[up_i, down_up_j] == 1 || map[up_i, down_up_j] == psValue || map[up_i, down_up_j] == 4 || map[up_i, down_up_jj] == 1 || map[up_i, down_up_jj] == psValue) { varY = 0; Y = posY; }
                    this.row = 1;
                    break;
                case "Down":
                    varY =5;
                    varX = 0;
                    posY= Y;
                    if ((donw_i > 6) || map[donw_i, down_up_j] == 1 || map[donw_i, down_up_j] == psValue || map[donw_i, down_up_j] == 4 || map[donw_i, down_up_jj] == 1 || map[donw_i, down_up_jj] == psValue) { Y = posY; varY = 0; }
                    this.row = 0;
                    break;
                case "Z" :
                    
                    if (map[((Y - 36) + this.Height) / 32, ((X - 42) + this.Width / 2) / 33] != 2)
                    {
                        int xx = (X + Width / 3) / 33;
                        xx = xx * 33 + 8;
                        int yy = (Y + this.Height / 2) / 32;
                        yy = yy * 32;
                        makeBomb(xx, yy);    
                    }




                    
                    break;
                default:
                    varX = varY = 0;;
                    break;

            }
            if (varX != 0 || varY != 0)
            {

                this.col++;
                if(this.col>3) this.col=0;
            }
            else
            {
                this.col = 0;
            }


            



            this.X += varX;
            this.Y += varY;


        }

        private void makeBomb(int x, int y)
        {

            bmb = new Bomb(x, y,3,this.map,imgBomb);
            bmbs.Add(bmb);
        }

       

        private void DrawBomb(System.Drawing.Graphics gr) {
            for (int i = 0; i < bmbs.Count; i++)
            {
                bmbs[i].move(gr);
                if (bmbs[i].xplote) {
                    bmbs[i].Dispose();
                    bmbs.Remove(bmbs[i]);
                };
            }
        
        }



    }
}
