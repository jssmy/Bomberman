using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace jssplay.levels
{
    public class first
    {
        public String Key;
        private System.Drawing.Bitmap d_w;
        private System.Drawing.Bitmap s_w;
        private System.Drawing.Bitmap backimg;
        private entity.Scenary scenary;
        private entity.Player player;
        private entity.Enemies enemies;
        
        public first(System.Drawing.Bitmap imgPlayer, int n_player)
        {
            backimg = new System.Drawing.Bitmap(Properties.Resources.Fundo1);
            d_w = new System.Drawing.Bitmap(Properties.Resources.W11_1);
            s_w = new System.Drawing.Bitmap(Properties.Resources.W11);
            scenary = new entity.Scenary(d_w,s_w,backimg,1,n_player );
            player = new entity.Player(42,14,imgPlayer,scenary.Map);
            this.enemies = new entity.Enemies(1);        
        }
        
        public void Draw(System.Drawing.Graphics gr)
        {
            
            scenary.Draw(gr);
            
            player.move(Key, gr);
            enemies.Draw(gr);
            if (player.explote) {
              
                scenary.DeleteItem(player.postMatrix);
                
                player.map = scenary.Map;
                player.explote = false;
                if (player.state){
                    scenary.life = player.live;
                    if(player.live<=0){
                       // this.gameOver = true;
                        scenary.gameOver = false;
                    }
                    };
            }


        }


    }
}
