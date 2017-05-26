using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Enemies
    {
        private List<Enemy> enemies;
        private int[,] Map;
        private Maps maps;
        private int level;
        private List<System.Drawing.Point> rectric;
        public Enemies(int level) {
            this.level = level;
            maps = new Maps(level);
            this.Map = maps.Map;
            this.maps = null;
            enemies = new List<Enemy>();
            this.rectric = new List<System.Drawing.Point>();
            this.Initialize();
            
        }

        public void Draw(System.Drawing.Graphics gr)
        {
            for(int i=0; i <enemies.Count; i++){
                //enemies[i].Draw(gr);
                enemies[i].move(gr);
                //System.Drawing.Pen pen = new System.Drawing.Pen(Color.Red, 2);
                //System.Drawing.Rectangle rec = new Rectangle(enemies[i].X,enemies[i].Y+enemies[i].Height/2+3,enemies[i].Width,enemies[i].Height/2);
                //gr.DrawRectangle(pen, rec);
                enemies[i].Key = CheckRestriction(enemies[i].X, enemies[i].Y + enemies[i].Height / 2 + 3, enemies[i].Width, enemies[i].Height / 2, enemies[i].Key);
            }
        }

        public void Initialize()
        {
            for (int i = 0; i < this.Map.GetLength(0); i++)
            {
                for (int j = 0; j< this.Map.GetLength(1); j++)
                {
                    int x = 33 * j + 42;
                    int y = 32 * i + 36;
                    if (this.Map[i, j] == 5)
                    {
                        Enemy e = new Enemy(x+3,y-22,4,3,Properties.Resources.ghost);
                        e.Key = SetDir(((e.Y + e.Height / 2 + 3) - 36) / 32, ((e.X + e.Width / 2) - 42) / 32);
                        enemies.Add(e);
                        
                    }
                    if (this.Map[i, j] == 1 || this.Map[i, j] == 2)
                    {
                        System.Drawing.Point p = new System.Drawing.Point(x,y);
                        rectric.Add(p);
                    }
                }

            }

        }

        public String CheckRestriction(int x, int y, int w, int h, String key) {
            for (int i = 0; i < rectric.Count; i++)
            {
                System.Drawing.Point p = rectric[i];
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(p.X,p.Y,32,32);
                System.Drawing.Rectangle ene = new System.Drawing.Rectangle(x,y,w,h);
                if (key.Equals("Right") )
                {
                    ene = new System.Drawing.Rectangle(x,y,w+5,h);
                    if (rect.IntersectsWith(ene) || x + w + 5 > 480) return "Left";
                }
                if (key.Equals("Left")  )
                {
                    ene = new System.Drawing.Rectangle(x-5, y, w,h);
                    if (rect.IntersectsWith(ene) || x - 5 < 42) return "Right";
                }
                if (key.Equals("Up"))
                {
                    
                    ene = new System.Drawing.Rectangle(x,y-5,w,h);
                    if (rect.IntersectsWith(ene) || y - 5 < 36) return "Down";
                }
                if (key.Equals("Down"))
                {
                    ene = new System.Drawing.Rectangle(x,y,w,h+5);
                    if (rect.IntersectsWith(ene) || y + h + 5 > 272) return "Up";
                }
                 
            }

                return key;
        }


        private String SetDir(int i, int j)
        {
            String d = "";
            //evelua derecha
            if (Map[i, j+1] != 1 && Map[i,j+1]!=2)
            {
                d= "Right";
            }
            //evalua izquierda
            if (Map[i, j - 1] != 1 && Map[i, j-1] != 2)
            {
                d= "Left";
            }
            //evalua abajo
            if (Map[i+1, j ] != 1 && Map[i+1,j ] != 2)
            {
                d= "Down";
            }
            //evalua arriba
            if (Map[i-1,j] != 1 && Map[i-1, j] != 2)
            {
                d= "Up";
            }
            return d;

        }



    }
}
