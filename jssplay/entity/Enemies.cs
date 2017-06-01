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
        public int[,] Map { get; set; }
        private Maps maps;
        private int level;
        private List<System.Drawing.Point> rectric;
        public bool player_state { get; set; }
        public Enemies(int level) {
            this.level = level;
            maps = new Maps(level);
            this.Map = maps.Map;
            this.maps = null;
            enemies = new List<Enemy>();
            this.rectric = new List<System.Drawing.Point>();
            this.Initialize();
            
        }

        public void Draw(System.Drawing.Graphics gr, int px, int py, int pw, int ph)
        {
            this.player_state = false;
            int size = enemies.Count;
            for(int i=0; i <size; i++){
                //enemies[i].Draw(gr);
                enemies[i].Draw(gr);
                
                enemies[i].Key = CheckRestriction(enemies[i].X, enemies[i].Y + enemies[i].Height / 2 + 3, enemies[i].Width, enemies[i].Height / 2, enemies[i].Key);
                /// verifica si ha colicionado con el jugado
                if (!this.player_state) this.player_state = CheckPlayerColition(px, py, pw, ph, enemies[i].X, enemies[i].Y, enemies[i].Width, enemies[i].Height);
                /// si el enemio se encuentra en estado true para morir
                if (!enemies[i].state) enemies[i].KeyMove();
                else
                {
                    if (enemies[i].Died())
                    {
                        enemies.Remove(enemies[i]);
                        i--;
                        size--;
                    }
                }

                //verifica si el enemigo ha sido colicionado con la bomba
                

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
                        Enemy e = new Enemy(x+3,y-22,5,3,Properties.Resources.ghostv2);
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

        public void InitializeRestrict()
        {
            rectric = new List<Point>();
            for (int i = 0; i < this.Map.GetLength(0); i++)
            {
                for (int j = 0; j < this.Map.GetLength(1); j++)
                {
                    int x = 33 * j + 42;
                    int y = 32 * i + 36;

                    if (this.Map[i, j] == 1 || this.Map[i, j] == 2)
                    {
                        System.Drawing.Point p = new System.Drawing.Point(x, y);
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
                //e.Key = SetDir(((e.Y + e.Height / 2 + 3) - 36) / 32, ((e.X + e.Width / 2) - 42) / 32);
                int ii = ((y + h / 2 + 3) - 36)/32;
                int jj = ((x + w / 2) - 42) / 32;
                if (key.Equals("Right") )
                {
                    ene = new System.Drawing.Rectangle(x,y,w+5,h);
                    if (rect.IntersectsWith(ene) || x + w + 5 > 480-42) {
                        ii = ((ene.Y + ene.Height / 2 + 3) - 36) / 32;
                        //validar arriba

                        return SetDir(ii,jj);
                        
                    }
                }
                if (key.Equals("Left")  )
                {
                    ene = new System.Drawing.Rectangle(x-5, y, w,h);
                    if (rect.IntersectsWith(ene) || x - 5 < 42)
                    {
                        return SetDir(ii, jj);

                    }
                }
                if (key.Equals("Up"))
                {
                    
                    ene = new System.Drawing.Rectangle(x,y-5,w,h);
                    if (rect.IntersectsWith(ene) || y - 5 < 38) {
                        return SetDir(ii, jj);
                    }
                }
                if (key.Equals("Down"))
                {
                    ene = new System.Drawing.Rectangle(x, y, w, h + 5);
                    if (rect.IntersectsWith(ene) || y + h + 5 > 272)
                    {
                        return SetDir(ii, jj);
                    }
                }
                 
            }

                return key;
        }
        
        private String SetDir(int i, int j)
        {
            String d = "";
            if (j < 6)
            {
                //evelua derecha
                if (Map[i, j + 1] != 1 && Map[i, j + 1] != 2)
                {
                    d = "Right";
                }
            }
            if (j > 0)
            {
                //evalua izquierda
                if (Map[i, j - 1] != 1 && Map[i, j - 1] != 2)
                {
                    d = "Left";
                }
            }
            if (i < 6)
            {
                //evalua abajo
                if (Map[i + 1, j] != 1 && Map[i + 1, j] != 2)
                {
                    d = "Down";
                }
            }
            if (i > 0)
            {
                //evalua arriba
                if (Map[i - 1, j] != 1 && Map[i - 1, j] != 2)
                {
                    d = "Up";
                }
            }
            return d;

        }

        public bool CheckPlayerColition(int x, int y, int w, int h, int ex, int ey, int ew, int eh)
        {
            
            System.Drawing.Rectangle player = new System.Drawing.Rectangle(x, y+h/2, w, h/2);
            System.Drawing.Rectangle enemie = new System.Drawing.Rectangle(ex, ey+h/2, ew, eh/2);
            if (player.IntersectsWith(enemie))
            {
                return true;
            }
            return false;
        }
        public void EvaluateExplotion(List<Point> posFlame)
        {

            /// tener en cuenta que las predes tiene de dimension 32x32
            /// que las paredes se encuetran en un marge de 42 del eje x y 36 del eje y

            if (posFlame.Count > 0)
            {
                System.Drawing.Rectangle vertical = new System.Drawing.Rectangle(posFlame[0].X + 5, posFlame[0].Y, 30 - 5, posFlame[1].Y - posFlame[0].Y);
                System.Drawing.Rectangle horizontal = new System.Drawing.Rectangle(posFlame[2].X, posFlame[2].Y + 5, posFlame[3].X - posFlame[2].X, 30 - 5);
                //System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.Blue, 3);
                foreach (Enemy e in enemies)
                {
                    //enemies[i].Key = CheckRestriction(enemies[i].X, enemies[i].Y + enemies[i].Height / 2 + 3, enemies[i].Width, enemies[i].Height / 2, enemies[i].Key);
                    System.Drawing.Rectangle ene = new System.Drawing.Rectangle(e.X, e.Y + e.Height / 2, e.Width, e.Height / 2);
                    if (vertical.IntersectsWith(ene) || horizontal.IntersectsWith(ene))
                    {
                        //e = new Enemy(e.X,e.Y,5,2,Properties.Resources.ghostv2);
                        e.div_col = 2;
                        /// e.X = e.X - 5;
                        e.Size();
                        e.state = true;

                    }
                }
            }
        }

    }
}
