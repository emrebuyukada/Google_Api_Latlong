using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gezinti_teorisi
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        Thread t;
        TcpClient baglantikur;
        NetworkStream ag;
        StreamReader oku;
        StreamWriter yaz;
        public delegate void ricdegis(string text);

        public void okumayabasla()
        {
            ag = baglantikur.GetStream();
            oku = new StreamReader(ag);
            while (true)
            {
                try
                {
                    string yazi = oku.ReadLine();
                    ekranabas(yazi);
                }
                catch
                {
                    return;
                }
            }
        }
        public void ekranabas(string s)
        {
            if (this.InvokeRequired)
            {
                ricdegis degis = new ricdegis(ekranabas);
                this.Invoke(degis, s);
            }
            else
            {
                s = "" + s;
                richTextBox1.AppendText(s + "\n");
            }
        }
        public void baglanti_kur()
        {

            //Ben Lochalhos üzerinde deneme yapacagim icin 127.0.0.1 verdim 192.168.1.105
            baglantikur = new TcpClient("30.10.21.41", Convert.ToInt16(txtPort.Text));
            t = new Thread(new ThreadStart(okumayabasla));
            t.Start();
           // richTextBox1.AppendText(DateTime.Now.ToString() + " Baglanti kuruldu...\n");
        }


        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void btnbaglan_Click(object sender, EventArgs e)
        {
            baglanti_kur();
        }


// indeksleme ve indirgeme için Ham datayı Gönderiyorum Geri kalanını Server Hallediyor.
        private void gonder_Click(object sender, EventArgs e)
        {
            
           
            string dosya_yolu = @"C:/Users/emre/Downloads/20081027113404.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
           
            string[] parca;
            string gonder = "";
            int sayac=0;
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                sayac++;
                yazi = sw.ReadLine();
            }
            sw.Close();
            fs.Close();
            gonder = sayac.ToString()+"\n";

            FileStream fse = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader swe = new StreamReader(fse);


          string  yazi1 = swe.ReadLine();
            while (yazi1 != null)
            {
                parca = yazi1.Split(',');

                gonder = gonder + parca[0] + "," + parca[1] +"\n" ;
                sayac++;
                yazi1 = swe.ReadLine();
            }
            swe.Close();
            fse.Close();


            if (gonder == "")
                //Burda bos alan göndermeyi önlüyoruz...
                return;
            else
            {
                yaz = new StreamWriter(ag);
                yaz.WriteLine(gonder);
                yaz.Flush();
                //  richTextBox1.AppendText(textBox2.Text + "\n");

            }
            
        }

        private void btnBaglantiKes_Click(object sender, EventArgs e)
        {
            baglantikur.Client.Close();
            MessageBox.Show("ss");
        }
        Label lbl = new Label();
        private void button1_Click(object sender, EventArgs e)
        {
            bool t = true; int i = 0;
            string a = "";
            while (t)
            {
                a = richTextBox1.Lines[i];
                if (a != "")
                {
                    lbl.Text += richTextBox1.Lines[i] + "\n";
                }
                else
                {
                    t = false;
                }
                i++;
            }
            // MessageBox.Show(lbl.Text);

            string dosya_yolu = @"C:\indirgeme.txt";
            if (File.Exists(@"C:\indirgeme.txt")) { File.Delete(dosya_yolu); } //Var olan dosyayı silip tekrar yüklüyorizki guncel olsun
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(lbl.Text);
            sw.Flush();
            sw.Close();
            fs.Close();
            MessageBox.Show("İşlem Bitti diğer forma geçiniz... ");
        }
    }
}
