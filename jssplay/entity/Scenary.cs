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
        public int[,] Map;
        
        /// <summary>
        /// /times
        /// </summary>
        
        private Time min;
        private Time sec1;
        private Time sec2;
        private Time igual;
        private int i;
        private int m;
        private int s1;
        private int s2;
        private int cs1;
        private int cs2;
        private int cm;
        //
        private System.Drawing.Bitmap d_wimg;
        private System.Drawing.Bitmap s_wimg;

        private Dinamic_wall dinamicw;
        private Static_wall staticw;
        Image backroud = null;


        public Scenary(Bitmap d_w, Bitmap s_w, Bitmap bckimg, int level) {
            walls_dinamics = new List<Dinamic_wall>();
            walls_statics = new List<Static_wall>();
            
            
            d_wimg = d_w;
            s_wimg = s_w;
            dinamicw = new Dinamic_wall(0,0,0, 0, d_wimg);
            staticw = new Static_wall(0, 0,0,0, s_wimg);
            
            this.backroud = new Image(0,0,bckimg);
            map = new Maps(level);
            Map = map.Map;
            
            min = new Time(90,5,10, Properties.Resources.numTempo);
            sec2 = new Time(110,5,10, Properties.Resources.numTempo);
            sec1 = new Time(120, 5, 10, Properties.Resources.numTempo);
            igual = new Time(100,5,1, Properties.Resources.igual);

            create_map();

        }
        public void create_map(){
            for (int i = 0; i < map.Map.GetLength(0); i++){
                for (int j = 0; j < map.Map.GetLength(1); j++)
                {
                    int x = staticw.image.Width * j + 42;
                    int y = staticw.image.Height * i + 36;
                    if (map.Map[i, j] == 1)
                    {
                        staticw = new Static_wall(x,y,i,j,s_wimg);
                        

                        walls.Add(staticw);
                    }
                    else if (map.Map[i, j] == 2)
                    {

                        dinamicw = new Dinamic_wall(x,y,i,j,d_wimg);
                        walls.Add(dinamicw);
                        
                    }
                    

                }
            }
            this.Map = map.Map;
            map = null;

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

            backroud.Draw(gr);
            runTime(gr);
            
            
            for (int i = 0; i < walls.Count; i++) {
                    walls[i].Draw(gr);
                                     
            }

            
        }

        public void Dispose()
        {

            
        }




    }
}
