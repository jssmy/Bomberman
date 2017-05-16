using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jssplay.entity
{
    public class Flame
    {
        private int[,] Matrix;

        private Image center = null; ///
        private Image DerechaFinal = null;
        private Image Derecha = null;
        private Image IzquierdaFinal = null;
        private Image Izquierda = null;
        private Image ArribaFinal = null;
        private Image Arriba = null;
        private Image AbajoFinal = null;
        private Image Abajo = null;
        private int level;
        private int X;
        private int Y;
        private int w;
        private int h;
        
        List<int> posMatrix { get; set; }
        List<int> posMatrixItems { get; set; }

        public  Flame(int x, int y,int level, int [,] matrix) {
            
            this.level = level;
            center = new Image(x,y,Properties.Resources.C1);
            Derecha = new Image(center.X+center.image.Width,center.Y,Properties.Resources.C4);
            DerechaFinal = new Image(Derecha.X+Derecha.image.Width,Derecha.Y,Properties.Resources.C10);
            Izquierda = new Image(center.X-center.image.Width,center.Y,Properties.Resources.C4);
            IzquierdaFinal = new Image(Izquierda.X-Izquierda.image.Width,Izquierda.Y,Properties.Resources.C7);
            Abajo = new Image(center.X, center.Y+center.image.Height,Properties.Resources.C19);
            AbajoFinal = new Image(Abajo.X, Abajo.Y+Abajo.image.Height, Properties.Resources.C16);
            Arriba = new Image(center.X,center.Y-center.image.Height,Properties.Resources.C19);
            ArribaFinal = new Image(Arriba.X,Arriba.Y-Arriba.image.Height,Properties.Resources.C13);
            this.Matrix = matrix;
            this.posMatrix = new List<int>();
            this.posMatrixItems = new List<int>();
            this.posFlame = new List<System.Drawing.Point>();
        }
        public void Draw(System.Drawing.Graphics gr) {
            Derecha.Draw(gr);
            DerechaFinal.Draw (gr);

            Abajo.Draw(gr);
            AbajoFinal.Draw(gr);

            Arriba.Draw(gr);
            ArribaFinal.Draw(gr);

            Izquierda.Draw(gr);
            IzquierdaFinal.Draw(gr);

            center.Draw(gr);
        }

        private void Size(){}
        public List<int> posMatrixxItems(){   return posMatrixItems;}
        public List<int> posMatrixx(){return posMatrix;}  /// retorna las pociones de la llama en la matriz
                                                          /// 
        
        ///<summary>
        /// Estas funciones lo que hacen es calcular la posicion de los itemss en la matriz
        /// recordar que algunas paredes tiene items, estos items se muestran cuando las paredes son explotadass
        /// </summary>


        private void setItemsPos_Center()
        {
            int i = ((center.Y - 36) + center.Height / 2) / 32; /// obtiene la posicion i de la llama en la matriz
            int j = ((center.X - 42) + center.Width / 2) / 33; // obtiene la posicion j de la llama en la matriz
            posMatrixItems.Add(i); // aniade las pocisiones
            posMatrixItems.Add(j); // anidade las pociciones
        }
        private void setItemPos_Derecha()
        {
            int i = ((Derecha.Y - 36) + Derecha.Height / 2) / 32;
            int j = (((Derecha.X - 42) + Derecha.Width / 2) / 33);
            posMatrixItems.Add(i);
            posMatrixItems.Add(j);

        }
        private void setItemPos_DerechaF()
        {
            int i = ((DerechaFinal.Y - 36) + DerechaFinal.Height / 2) / 32;
            int j = (((DerechaFinal.X - 42) + DerechaFinal.Width / 2) / 33);
            posMatrixItems.Add(i);
            posMatrixItems.Add(j);
        }
        private void setItem_Pos_Izquierda()
        {
            int i = ((Izquierda.Y - 36) + Izquierda.Height / 2) / 32;
            int j = (((Izquierda.X - 42) + Izquierda.Width / 2) / 33);
            posMatrixItems.Add(i);
            posMatrixItems.Add(j);
        }
        private void setItemPos_IzquierdaF()
        {
            int i = ((IzquierdaFinal.Y - 36) + IzquierdaFinal.Height / 2) / 32;
            int j = ((IzquierdaFinal.X - 42) + IzquierdaFinal.Width / 2) / 33;
            posMatrixItems.Add(i);
            posMatrixItems.Add(j);
        }
        private void setItemPos_Arriba()
        {
            int i = (((Arriba.Y - 32) + Arriba.Height / 2) / 32);
            int j = ((Arriba.X - 42) + Arriba.Width / 2) / 33;
            posMatrixItems.Add(i);
            posMatrixItems.Add(j);
        }
        private void setItemPos_ArribaF()
        {
            int i = ((ArribaFinal.Y - 32) + ArribaFinal.Height / 2) / 32;
            int j = ((ArribaFinal.X - 42) + ArribaFinal.Width / 2) / 33;
            posMatrixItems.Add(i);
            posMatrixItems.Add(j);

        }
        private void setItemPos_Abajo()
        {
            int i = (((Abajo.Y - 36) + Abajo.Height / 2) / 32);
            int j = ((Abajo.X - 42) + Abajo.Width / 2) / 33;
            posMatrixItems.Add(i);
            posMatrixItems.Add(j);
        }
        private void setItem_AbajoF()
        {
            int i = ((AbajoFinal.Y - 36) + AbajoFinal.Height / 2) / 32;
            int j = ((AbajoFinal.X - 42) + AbajoFinal.Width / 2) / 33;
            posMatrixItems.Add(i);
            posMatrixItems.Add(j);
        }


        ///cuando escribi este codigo solo dios y yo lo conociamos
        ///ahora solo dios lo sabe
        /// <summary>
        /// / estas funciones definir nuevas cooredenadass para las llamas
        /// es de acuerdo si ha encontrado alguna pared
        /// si encuentra alguna pared la llama se acorta
        /// ademas encuentra lass posiciones dentro de la matriz
        /// esto servira luego para identificar por donde pasa la llama y poder eliminar algunass paredes
        /// en caso que sea necesario
        /// en algunos casos, por ejemplo, se superppone las imagenes para determinar el tamanio de las llamas
        /// </summary>
        
        private void OptionDerecha()
        {

            //------------
            int derecha_i = ((Derecha.Y - 36) + Derecha.Height / 2) / 32;
            int derecha_j = ((Derecha.X - 42) + Derecha.Width / 2) / 33;
            int derechaF_i = ((DerechaFinal.Y - 36) + DerechaFinal.Height / 2) / 32;
            int derechaF_j = ((DerechaFinal.X - 42) + DerechaFinal.Width / 2) / 33;
            if (derecha_j >= 12)
            {
                Derecha.X = center.X;
                Derecha.Y = center.Y;
                DerechaFinal.X = center.X;
                DerechaFinal.Y = center.Y;
                derecha_i = ((Derecha.Y - 36) + Derecha.Height / 2) / 32;
                derecha_j = ((Derecha.X - 42) + Derecha.Width / 2) / 33;
                derechaF_i = ((DerechaFinal.Y - 36) + DerechaFinal.Height / 2) / 32;
                derechaF_j = ((DerechaFinal.X - 42) + DerechaFinal.Width / 2) / 33;
            }
            if (derechaF_j >= 12)
            {
                DerechaFinal.X = center.X;
                DerechaFinal.Y = center.Y;
                derechaF_i = ((DerechaFinal.Y - 36) + DerechaFinal.Height / 2) / 32;
                derechaF_j = ((DerechaFinal.X - 42) + DerechaFinal.Width / 2) / 33;
            }
            //---------------
            //int h 

            if (Matrix[derecha_i, derecha_j] == 1)
            {
                Derecha.X = center.X;
                Derecha.Y = center.Y;
                DerechaFinal.X = center.X;
                DerechaFinal.Y = center.Y;
            }
            else if (Matrix[derechaF_i, derechaF_j] == 1)
            {
                DerechaFinal.X = center.X;
                DerechaFinal.Y = center.Y;
            }


            if (Matrix[derecha_i, derecha_j] == 2)
            {
                DerechaFinal.X = Derecha.X;
                DerechaFinal.Y = Derecha.Y;
                derechaF_i = ((DerechaFinal.Y - 36) + DerechaFinal.Height / 2) / 32;
                derechaF_j = ((DerechaFinal.X - 42) + DerechaFinal.Width / 2) / 33;
                Derecha.X = center.X;
                Derecha.Y = center.Y;
                int i = derecha_i;
                int j = derecha_j;
                posMatrix.Add(i);
                posMatrix.Add(j);
            }
            else
            {
                setItemPos_Derecha();
            }
            if (Matrix[derechaF_i, derechaF_j] == 2)
            {
                //**retornar id **//
                int i = derechaF_i;
                int j = derechaF_j;
                posMatrix.Add(i);
                posMatrix.Add(j);
            }
            else
            {
                setItemPos_DerechaF();
            }
        }
        private void OptionIzquierda()
        {
            int izquierda_i = ((Izquierda.Y - 36) + Izquierda.Height / 2) / 32;
            int izquierda_j = ((Izquierda.X - 42) + Izquierda.Width / 2) / 33;
            int izquierdaF_i = ((IzquierdaFinal.Y - 36) + IzquierdaFinal.Height / 2) / 32;
            int izquierdaF_j = ((IzquierdaFinal.X - 42) + IzquierdaFinal.Width / 2) / 33;

            if (Matrix[izquierda_i, izquierda_j] == 1 || Izquierda.X < 45)
            {
                Izquierda.X = center.X;
                Izquierda.Y = center.Y;
                IzquierdaFinal.X = center.X;
                IzquierdaFinal.Y = center.Y;
                izquierda_i = ((Izquierda.Y - 36) + Izquierda.Height / 2) / 32;
                izquierda_j = ((Izquierda.X - 42) + Izquierda.Width / 2) / 33;
                izquierdaF_i = ((IzquierdaFinal.Y - 36) + IzquierdaFinal.Height / 2) / 32;
                izquierdaF_j = ((IzquierdaFinal.X - 42) + IzquierdaFinal.Width / 2) / 33;

            }
            else if (Matrix[izquierdaF_i, izquierdaF_j] == 1)
            {
                IzquierdaFinal.X = center.X;
                IzquierdaFinal.Y = center.Y;
            }

            if (Matrix[izquierda_i, izquierda_j] == 2)
            {
                IzquierdaFinal.X = Izquierda.X;
                IzquierdaFinal.Y = Izquierda.Y;
                izquierdaF_i = ((IzquierdaFinal.Y - 36) + IzquierdaFinal.Height / 2) / 32;
                izquierdaF_j = ((IzquierdaFinal.X - 42) + IzquierdaFinal.Width / 2) / 33;
                Izquierda.X = center.X;
                Izquierda.Y = center.Y;
                int i = izquierda_i;
                int j = izquierda_j;
                posMatrix.Add(i);
                posMatrix.Add(j);

            }
            else
            {
                setItem_Pos_Izquierda();
            }
            if (Matrix[izquierdaF_i, izquierdaF_j] == 2)
            {
                int i = izquierdaF_i;
                int j = izquierdaF_j; ;
                posMatrix.Add(i);
                posMatrix.Add(j);

            }
            else
            {
                setItemPos_IzquierdaF();
            }
        }
        private void OptionArriba()
        {
            int arriba_i = ((Arriba.Y - 36) + Arriba.Height / 2) / 32;
            int arriba_j = ((Arriba.X - 42) + Arriba.Width / 2) / 33;
            int arribaF_i = ((ArribaFinal.Y - 36) + ArribaFinal.Height / 2) / 32;
            int arribaF_j = ((ArribaFinal.X - 42) + ArribaFinal.Width / 2) / 33;
            if (arribaF_i < 0)
            {
                ArribaFinal.X = center.X;
                ArribaFinal.Y = center.Y;
                arribaF_i = ((ArribaFinal.Y - 36) + ArribaFinal.Height / 2) / 32;
                arribaF_j = ((ArribaFinal.X - 42) + ArribaFinal.Width / 2) / 33;
            }
            if (Matrix[arriba_i, arriba_j] == 1)
            {
                Arriba.X = center.X;
                Arriba.Y = center.Y;
                ArribaFinal.X = center.X;
                ArribaFinal.Y = center.Y;
                arribaF_i = ((ArribaFinal.Y - 36) + ArribaFinal.Height / 2) / 32;
                arribaF_j = ((ArribaFinal.X - 42) + ArribaFinal.Width / 2) / 33;
            }
            else if (Matrix[arribaF_i, arribaF_j] == 1)
            {
                ArribaFinal.X = center.X;
                ArribaFinal.Y = center.Y;
                arribaF_i = ((ArribaFinal.Y - 36) + ArribaFinal.Height / 2) / 32;
                arribaF_j = ((ArribaFinal.X - 42) + ArribaFinal.Width / 2) / 33;
            }

            if (Matrix[arriba_i, arriba_j] == 2)
            {

                ArribaFinal.X = Arriba.X;
                ArribaFinal.Y = Arriba.Y;
                arribaF_i = ((ArribaFinal.Y - 36) + ArribaFinal.Height / 2) / 32;
                arribaF_j = ((ArribaFinal.X - 42) + ArribaFinal.Width / 2) / 33;
                Arriba.Y = center.Y;
                Arriba.X = center.X;
                /// significa que se ha encontrado una pared sin item
                int i = arriba_i; ;
                int j = arriba_j;
                //  primero se ha agregado la llama que no es final, es decir no es el extremo de la llama
                posMatrix.Add(i);
                posMatrix.Add(j);
            }
            else
            {   
                /// significa que la paren con el que ha colisionado la llama tiene un item
                setItemPos_Arriba();
            }
            if (Matrix[arribaF_i, arribaF_j] == 2)
            {
                //se ha agrega por en segundo lugar la posicion de la llama final, es decir el extremmo  de la llama
                int i = arribaF_i;
                int j = arribaF_j;
                posMatrix.Add(i);
                posMatrix.Add(j);
            }
            else
            {
                setItemPos_ArribaF();
            }
        }
        private void OptionAbajo()
        {
            int abajo_i = ((Abajo.Y - 36) + Abajo.Height / 2) / 32;
            int abajo_j = ((Abajo.X - 42) + Abajo.Width / 2) / 33;
            int abajoF_i = ((AbajoFinal.Y - 36) + AbajoFinal.Height / 2) / 32;
            int abajoF_j = ((AbajoFinal.X - 42) + AbajoFinal.Width / 2) / 33;
            if (abajo_i >= 7)
            {
                Abajo.X = center.X;
                Abajo.Y = center.Y;
                AbajoFinal.X = center.X;
                AbajoFinal.Y = center.Y;
                abajo_i = ((Abajo.Y - 36) + Abajo.Height / 2) / 32;
                abajo_j = ((Abajo.X - 42) + Abajo.Width / 2) / 33;
                abajoF_i = ((AbajoFinal.Y - 36) + AbajoFinal.Height / 2) / 32;
                abajoF_j = ((AbajoFinal.X - 42) + AbajoFinal.Width / 2) / 33;
            }
            if (abajoF_i >= 7)
            {
                AbajoFinal.X = center.X;
                AbajoFinal.Y = center.Y;
                abajoF_i = ((AbajoFinal.Y - 36) + AbajoFinal.Height / 2) / 32;
                abajoF_j = ((AbajoFinal.X - 42) + AbajoFinal.Width / 2) / 33;
            }
            if (Matrix[abajo_i, abajo_j] == 1)
            {
                Abajo.X = center.X;
                Abajo.Y = center.Y;
                AbajoFinal.X = center.X;
                AbajoFinal.Y = center.Y;
                abajoF_i = ((AbajoFinal.Y - 36) + AbajoFinal.Height / 2) / 32;
                abajoF_j = ((AbajoFinal.X - 42) + AbajoFinal.Width / 2) / 33;
            }
            if (Matrix[abajoF_i, abajoF_j] == 1)
            {
                AbajoFinal.X = center.X;
                AbajoFinal.Y = center.Y;
                abajoF_i = ((AbajoFinal.Y - 36) + AbajoFinal.Height / 2) / 32;
                abajoF_j = ((AbajoFinal.X - 42) + AbajoFinal.Width / 2) / 33;
            }
            if (Matrix[abajo_i, abajo_j] == 2)
            {
                AbajoFinal.X = Abajo.X;
                AbajoFinal.Y = Abajo.Y;
                abajoF_i = ((AbajoFinal.Y - 36) + AbajoFinal.Height / 2) / 32;
                abajoF_j = ((AbajoFinal.X - 42) + AbajoFinal.Width / 2) / 33;
                Abajo.X = center.X;
                Abajo.Y = center.Y;
                int i = abajo_i + 1;
                int j = abajo_j;
                posMatrix.Add(i);
                posMatrix.Add(j);

            }
            else
            {
                setItemPos_Abajo();
            }
            if (Matrix[abajoF_i, abajoF_j] == 2)
            {
                int i = abajoF_i;
                int j = abajoF_j;
                posMatrix.Add(i);
                posMatrix.Add(j);
            }
            else
            {
                setItem_AbajoF();
            }
        }

        /// <summary>
        ///  esta llama unicamente almacena los ejes x y y de la llama horizonta y vertical
        /// </summary>
        public List<System.Drawing.Point> posFlame { get; set; }

        /// <summary>
        /// finalmente, la funcion GetSizeLlama se define las coordenadas finales
        /// para ello se llaman a todas las funciones que lo hacen
        /// aca se llaman a todas lass funciones para calcular tamanio de la llama
        /// </summary>
        public void GeTSizeLLama()
        {
            if (level==1)
            {
                Derecha.X = center.X;
                Derecha.Y = center.Y;
                Izquierda.X = center.X;
                Izquierda.Y = center.Y;
                Abajo.X = center.X;
                Abajo.Y = center.Y;
                Arriba.X = center.X;
                Arriba.Y = center.Y;
                //-----
                DerechaFinal.X = center.X + center.Width;
                DerechaFinal.Y = center.Y;
                IzquierdaFinal.X = center.X - IzquierdaFinal.Width;
                IzquierdaFinal.Y = center.Y;
                AbajoFinal.X = center.X;
                AbajoFinal.Y = center.Y + center.Height;
                ArribaFinal.X = center.X;
                ArribaFinal.Y = center.Y - ArribaFinal.Height;
            }
            /// se ubica de esta manera la pociion de estass funciones
            /// debido a   que luego se necesitara llas coordenadass de las llamas arribafinal
            /// y derecha final
            /// para evaluar la colision con el jugador
            /// se concluye que lass pociiones que se necesitara posteriormente se encuentra na
            /// matrix[2,3] -> Arriba final
            /// matrix[6,7] -> derecha final
            /// en  total hay 18 posiciones
            /// se sabe que si se obtien el primer par  posMatrixx[0] y posMatrix[1]  es i y j respectivamente
            /// de la llama Arriba
            OptionArriba();
            //-----------------------------------
            OptionDerecha();
            //---------------------------------------------------------
            OptionIzquierda();
            ///--------------------------------------------------------------
            
            ///--------------------------------------------------------------
            OptionAbajo();
            //-------
            ///--------------------------------------------------------------
            setItemsPos_Center();
            posMatrixx();
            ///insertar la pociocion de la llama horizontal y verticla
            System.Drawing.Point pt = new System.Drawing.Point(ArribaFinal.X, ArribaFinal.Y);
            posFlame.Add(pt); // en posFlame[0] -> VERITCAL
            pt = new System.Drawing.Point(DerechaFinal.X, DerechaFinal.Y);
            posFlame.Add(pt); // en posFlame[1]-> horizontal
        }

        /// <summary>
        /// esta funcion lo que hace es limpiar la memoria antes de eliminar la llama cuando
        /// </summary>
        public void Dispose()
        {
            this.Matrix = null;
            this.Derecha = null;
            this.DerechaFinal = null;
            this.Izquierda = null;
            this.IzquierdaFinal = null;
            this.Arriba = null;
            this.ArribaFinal = null;
            this.center = null;
            this.Abajo = null;
            this.AbajoFinal = null;
            

        }

        






    }
}
