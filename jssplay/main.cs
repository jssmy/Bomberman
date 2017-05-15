using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DS= Microsoft.DirectX.DirectSound;

///
using System.IO;
using System.Reflection;

namespace jssplay
{
    public partial class main : Form
    {
        controller.Controller con;
        
        public main()
        {
            
            InitializeComponent();
            con = new controller.Controller();
            

            

        }

        private void time_Tick(object sender, EventArgs e)
        {

            Graphics g = screen.CreateGraphics();
            BufferedGraphicsContext contexto = BufferedGraphicsManager.Current;
            BufferedGraphics buffer = contexto.Allocate(g, screen.DisplayRectangle);
            buffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            con.Draw(buffer.Graphics);
            buffer.Render(g);
            buffer.Dispose();
            g.Dispose();




        }

        private void main_Load(object sender, EventArgs e)
        {
           
            


        }

        private void main_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void main_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData.ToString().Equals("Escape")) { this.Close(); }
            con.Key = e.KeyData.ToString();
            
        }

        private void main_KeyUp(object sender, KeyEventArgs e)
        {
            con.Key = "-";
            if (e.KeyData.ToString().Equals("Return")) if (con.opcion == 2) this.Close();
        }
    }
}
