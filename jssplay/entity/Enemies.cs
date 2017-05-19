using System;
using System.Collections.Generic;
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
        public Enemies(int level) {
            this.level = level;
            maps = new Maps(level);
            this.Map = maps.Map;
            this.maps = null;
            enemies = new List<Enemy>();
            this.Initialize();

        }

        public void Draw(System.Drawing.Graphics gr)
        {
            for(int i=0; i <enemies.Count; i++){
                //enemies[i].Draw(gr);
                enemies[i].move(gr);
               // enemies[i].Key= CheckRestriction(enemies[i].X, enemies[i].Y,enemies[i].Width, enemies[i].Height, enemies[i].Key);
            }
        }

        public void Initialize()
        {
            for (int i = 0; i < this.Map.GetLength(0); i++)
            {
                for (int j = 0; j< this.Map.GetLength(1); j++)
                {
                    int x = 32 * j + 42;
                    int y = 32 * i + 36;
                    if (this.Map[i, j] == 5)
                    {
                        Enemy e = new Enemy(x,y-25,4,3,Properties.Resources.ghost);
                        e.Key = SetDir(i,j);
                        enemies.Add(e);

                    }
                }

            }

        }

        public String CheckRestriction(int x, int y, int w, int h, String key) {
            int i = ((y-36)+h/2)/32;
            int j = ((x-42)+w/2)/32 ;
            int v;
            Random r = new Random();
            switch (key)
            {
                case "Up":
                    if (this.Map[i, j-1] == 1 || this.Map[i, j-1] == 2 || y>32)
                    {
                        ///se tien tres opciones para moverse, abajo, derecha o iquierda
                        v = r.Next(1,3);
                        switch (v)
                        {
                            case 1:
                                if (this.Map[i, j + 1] != 1 || this.Map[i, j + 1] != 2) return "Down";
                                break;
                            case 2:
                                if (this.Map[i - 1, j] != 1 || this.Map[i - 1, j] != 2) return "Left";
                                break;
                            case 3:
                                if (this.Map[i, j + 1] != 1 || this.Map[i, j + 1] != 2) return "Right";
                                break;
                        }
                        
                    }
                 break;
                    
                case "Down":
                    if (this.Map[i, j+1] == 1 || this.Map[i, j+1] == 2 || y+w+w/2>272) {
                        v = r.Next(1,3);
                        switch(v){
                            case 1:
                                if (this.Map[i, j - 1] != 1 || this.Map[i, j - 1] != 2) return "Up";
                                break;
                            case 2:
                                if (this.Map[i - 1, j] != 1 || this.Map[i - 1, j] != 2) return "Left";
                                break;
                            case 3:
                                if (this.Map[i, j + 1] != 1 || this.Map[i, j + 1] != 2) return "Right";
                                break;
                        }
                    }
                 break;

                case "Left":
                        if (this.Map[i+1, j] == 1 || this.Map[i+1, j] == 2 || x<45) 
                        {

                            v = r.Next(1, 3);
                            switch (v)
                            {
                                case 1:
                                    if (this.Map[i, j + 1] != 1 || this.Map[i, j + 1] != 2) return "Down";
                                    break;
                                case 2:
                                    if (this.Map[i, j - 1] != 1 || this.Map[i, j - 1] != 2) return "Up";
                                    break;
                                case 3:
                                    if (this.Map[i, j + 1] != 1 || this.Map[i, j + 1] != 2) return "Right";
                                    break;

                            }
                        }
                    
                break;
                case "Right":
                if (this.Map[i+1, j] == 1 || this.Map[i+1, j] == 2 || x+w+w/2>480)
                {

                    v = r.Next(1, 3);
                    switch (v)
                    {
                        case 1:
                            if (this.Map[i, j + 1] != 1 || this.Map[i, j + 1] != 2) return "Down";
                            break;
                        case 2:
                            if (this.Map[i - 1, j] != 1 || this.Map[i - 1, j] != 2) return "Left";
                            break;
                        case 3:
                            if (this.Map[i, j - 1] != 1 || this.Map[i, j - 1] != 2) return "Up";
                            break;

                    }
                }
                break;
                 
                
            }            
                    

            

            return key;
        }


        private String SetDir(int i, int j)
        {
            Random r =  new Random();
            int v = 0;
            if (this.Map[i + 1, j] == 1 || this.Map[i + 1, j] == 2 || this.Map[i - 1, j] == 1 || this.Map[i - 1, j] == 2)
            {
                v = r.Next(0,1);
            }
            if (this.Map[i, j+1] == 1 || this.Map[i, j+1] == 2 || this.Map[i, j-1] == 1 || this.Map[i, j-1] == 2)
            {
                v = r.Next(2, 3);
            }
            if (v == 0) return "Up";
            if (v == 1) return "Down";
            if (v == 2) return "Left";
            if (v == 3) return "Right";

            return "-";

        }



    }
}
