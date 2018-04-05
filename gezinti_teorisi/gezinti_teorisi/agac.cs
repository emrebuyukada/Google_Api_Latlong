using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gezinti_teorisi
{
    public class agacNodu
    {
        public double x, y;//x lat  y long
        
        public agacNodu bir, uc, dort;
        public agacNodu iki;
        public agacNodu()
        {
        }
        public agacNodu(double x, double y, agacNodu bir, agacNodu iki, agacNodu uc, agacNodu dort)
        {
            this.x = x;
            this.y = y;
            this.bir = null;
            this.iki = null;
            this.uc = null;
            this.dort = null;
        }//consructor
    }

    class yapi
    {
        public static double tut = 31.771959, tut1 = 35.217018, k = 0; //dunyanın tam ortasının lat longu
        public agacNodu root;

    
        public yapi()//boş consructor
        { root = null; }


        public void ekle(double x, double y)
        {

           // MessageBox.Show("yeni cocuk");
            agacNodu yenidugum = new agacNodu(x, y, null, null, null, null);

            if (root == null)
            {
              //  MessageBox.Show("Root");
                root = yenidugum;
                tut = root.x;
                tut1 = root.y;

                return;
            }
            else
            {
                agacNodu current = root;
                agacNodu parent;

                while (true)
                {
                    parent = current;
                    if (x <= (current.x) && y <= (current.y))
                    {
                        tut = current.x;
                        tut1 = current.y;
                    //    MessageBox.Show("1. cocuk");
                        current = current.bir;
                        
                        if (current == null)
                        {
                            current = yenidugum;
                            parent.bir = yenidugum;

                            return;
                        }
                    }
                    else if (x >= (current.x) && y <= (current.y))
                    {

                        tut = current.x;
                        tut1 = current.y;


                        current = current.iki;
                     //   MessageBox.Show("2. cocuk");

                        if (current == null)
                        {
                            current = yenidugum;
                            parent.iki = current;

                            return;
                        }
                    }
                    else if (x <= (current.x) && y >= (current.y))
                    {
                        tut = current.x;
                        tut1 = current.y;
                     //   MessageBox.Show("3. cocuk");
                        current = current.uc;
                        if (current == null)
                        {

                            current = yenidugum;
                            parent.uc = current;

                            return;
                        }
                    }
                    else if (x >= (current.x) && y >= (current.y))
                    {
                        tut = current.x;
                        tut1 = current.y;
                       // MessageBox.Show("4. cocuk");

                        current = current.dort;

                        if (current == null)
                        {
                            current = yenidugum;
                            parent.dort = current;
                            return;
                        }
                    }
                }
            }
        }//ağaca ekleme işlemi
    }
}
