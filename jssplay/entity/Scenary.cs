using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace jssplay.entity
{
    public class Scenary
    {
        private List<Dinamic_wall> walls_dinamics = null;
        private List<Static_wall>  walls_statics = null;
        private List<Figure> walls = new List<Figure>();
        private Maps map = null;
        public int[,] Map{set;get;}
        
        /// <summary>
        /// /times
        /// </summary>
        
        private Number min;
        private Number sec1;
        private Number sec2;
        private Number igual;
        private Number Live;
        public int life { get; set; }
        private int i;
        private int m;
        private int s1;
        private int s2;
        private int cs1;
        private int cs2;
        private int cm;
        private int clife;
        public bool gameOver;
        //
        private System.Drawing.Bitmap d_wimg;
        private System.Drawing.Bitmap s_wimg;
        private Dinamic_wall dinamicw;
        private Static_wall staticw;
        Image backroud = null;

        public Boolean deleteP { set; get; }
        public Scenary(Bitmap d_w, Bitmap s_w, Bitmap bckimg, int level, int n_player) {

            this.gameOver = false;
            walls_dinamics = new List<Dinamic_wall>();
            walls_statics = new List<Static_wall>();

            life = 3;
            d_wimg = d_w;
            s_wimg = s_w;
            dinamicw = new Dinamic_wall(0,0,0, 0, d_wimg);
            staticw = new Static_wall(0, 0,0,0, s_wimg);
            
            this.backroud = new Image(0,0,bckimg);
            map = new Maps(level);
            this.Map = map.Map;
            map = null;
            min = new Number(90,5,10, Properties.Resources.numTempo);
            sec2 = new Number(110,5,10, Properties.Resources.numTempo);
            sec1 = new Number(120, 5, 10, Properties.Resources.numTempo);
            igual = new Number(100,5,1, Properties.Resources.igual);

            create_map();
            deleteP = false;
            LivePlayer(n_player);

        }

        private void LivePlayer(int player) {
            switch (player)
            {
                case 0:
                    this.Live = new Number(195,5,10,Properties.Resources.numTempo);
                    break;
                case 1:
                    this.Live = new Number(265, 5, 10, Properties.Resources.numTempo);
                    break;
                case 2:
                    this.Live = new Number(335, 5, 10, Properties.Resources.numTempo);
                    break;
                case 3:
                    this.Live = new Number(405, 5, 10, Properties.Resources.numTempo);
                    break;

            }
        }
        
        public void create_map(){
            for (int i = 0; i < Map.GetLength(0); i++){
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    int x = staticw.image.Width * j + 42;
                    int y = staticw.image.Height * i + 36;
                    if (Map[i, j] == 1)
                    {
                        staticw = new Static_wall(x,y,i,j,s_wimg);
                        

                        walls.Add(staticw);
                    }
                    else if (Map[i, j] == 2)
                    {

                        dinamicw = new Dinamic_wall(x,y,i,j,d_wimg);
                        walls.Add(dinamicw);
                        
                    }
                    

                }
            }
            

        }
        
        private void runTime(System.Drawing.Graphics gr){
            this.s1++;
            //this.m++;
            if (this.s1 == 5)
            {
                this.cs1++;
                this.s1 = 0;
                if (this.cs1 == 10) { this.cs1 = 0; this.cs2++; }
            }

            if (this.cs2 == 6)
            {
                this.m++;
                this.cm++;
                this.cs2=0;
                this.cs1=0;
                this.s1 = 0;
                this.s2 = 0;
            }
            i++;
            if (i == 2) i = 0;

            min.Draw(gr);
            sec1.Draw(gr);
            sec2.Draw(gr);
            igual.Draw(gr);
            min.move(cm, 0);
            sec1.move(cs1, 0);
            sec2.move(cs2, 0);
            igual.move(i,0);
        }

        public void Draw(System.Drawing.Graphics gr)
        {
            //bool st = false;
            backroud.Draw(gr);
            runTime(gr);
            DrawLive(gr);
            int size = walls.Count;

            for (int i = 0; i < size; i++)
            {
                Figure w = walls[i];
                w.Draw(gr);
                if (w.GetType().Equals(typeof(Dinamic_wall)))
                {
                    Dinamic_wall d = (Dinamic_wall)w;
                    bool st = false;
                    if (d.state) st = d.Die();

                    if (st)
                    {
                        walls.Remove(d);
                        i--;
                        size--;
                    }

                }
            }
            
        }

        public void DeleteItem(List<System.Drawing.Point>  posFlame, System.Drawing.Graphics gr)
        {
            
            System.Drawing.Rectangle vertical = new System.Drawing.Rectangle(posFlame[0].X+5, posFlame[0].Y, 30-5, posFlame[1].Y - posFlame[0].Y);
            System.Drawing.Rectangle horizontal = new System.Drawing.Rectangle(posFlame[2].X, posFlame[2].Y+5, posFlame[3].X - posFlame[2].X, 30-5);
            System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.Blue, 3);
            //gr.DrawRectangle(p,vertical);
            //gr.DrawRectangle(p,horizontal);
            
            foreach( Figure d in walls){
                
                if (d.GetType().Equals(typeof(Dinamic_wall)))
                {
                    
                    Dinamic_wall dn = (Dinamic_wall)d;
                    System.Drawing.Rectangle dnc = new System.Drawing.Rectangle(dn.X, dn.Y, dn.Width, dn.Height);
                    if (horizontal.IntersectsWith(dnc) || vertical.IntersectsWith(dnc))
                    {
                       // gr.DrawRectangle(p,dnc);
                        dn.state = true;
                        this.Map[dn.i, dn.j] = 0;
                        //return true;
                    } 
                }
            }

            //return false;


        }

        public void DrawLive(System.Drawing.Graphics gr) {
            Live.Draw(gr);
            Live.move(clife,0);
            switch (this.life)
            {
                case 0:
                    clife = 0;
                    break;
                case 1:
                    clife = 1;
                    break;
                    
                case 2:
                    clife = 2;
                    break;
                case 3:
                    clife = 3;
                    break;
            }
        }

        public void Dispose()
        {

            
        }




    }
}
