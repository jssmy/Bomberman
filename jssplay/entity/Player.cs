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
        public bool explote { get; set; }
        private List<Bomb> bmbs;
        public int[,] map{get;set;}
        private Bomb bmb;
        private System.Drawing.Bitmap imgBomb;
        private int live;
        private int score;
        public int varX{get; set;}
        public int varY { get; set; }
        private int posX = 0;
        private int posY = 0;
        private int psValue; /// es la variable que restringe pasar sobre la pared
        public bool state;
        public List<int> postMatrix { get; set; }

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
            postMatrix = new List<int>();
            //xplote = false;
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
            if (this.state)Died();
            else KeyMove();
            DrawBomb(gr);
            this.keyPress = keypss;
            
        }

        public void Died() {
            this.row = 4;
            this.col++;
            if (this.col > 3) this.col = 0;
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
                    this.explote = true;
                    
                    postMatrix = bmbs[i].posMatrix;
                    this.state= EvaluateExplotion(bmbs[i].posFlame(),2);
                    bmbs[i].Dispose();
                    bmbs.Remove(bmbs[i]);
                    
                };
            }
        
        }

        /// <summary>
        ///            ------
        ///            |_x_|
        ///            |   |
        ///  --------------------------
        ///  |  x |    |   |    |     |   
        ///  ----------|---------------
        ///            |   |
        ///            ------
        ///            |  |
        ///            ------
        /// En la calse Flame, la cual es la llama de la bomba cuando explota
        /// se calcula las pociciones de cada parte de la llama en en buffer, 
        /// como se ha visto estas se sobrepone una con otras para determinar el tamanio de la llama
        /// ademas se calcula cada posicion de ellas en la matrix
        /// las en la imagen de arribba muestra las coordenadass que se tomara para evaluar la colicion con el personaje
        /// es decir, se creara dos cuadros grandes de forma vertical y horizontal para coclisionar con las  dimensiones  y pocision del personaje
        /// claro que la llama tiene el nivel 1 y 2, la identifica el tamanio de esta, por lo que el algoritmo es lo siguiente
        /// </summary>
        /// <param name="postMaxtrix"></param>
        /// <param name="level"></param>
        public bool EvaluateExplotion(List<System.Drawing.Point> posFlame, int level)
        {
            
            /// tener en cuenta que las predes tiene de dimension 32x32
            /// que las paredes se encuetran en un marge de 42 del eje x y 36 del eje y
            System.Drawing.Rectangle horizontal = new System.Drawing.Rectangle(posFlame[1].X, posFlame[1].Y, 32*(2*level +1), 32);
            System.Drawing.Rectangle vertical = new System.Drawing.Rectangle(posFlame[0].X, posFlame[0].Y, 32, 32*(2*level+1));
            System.Drawing.Rectangle player = new System.Drawing.Rectangle(this.X, this.Y,this.Width, this.Height);
            if (horizontal.IntersectsWith(player)) return true; ;
            if (vertical.IntersectsWith(player)) return true;

            return false;
        }
        


    }
}
