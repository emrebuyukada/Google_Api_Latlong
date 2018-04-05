using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using System.IO;
using System.Net;


namespace gezinti_teorisi
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        ChromiumWebBrowser chrome;

        public static string son = "", deneme="";
        public static string merkez = "";
        public static string basla = "",bitir = "";

        static public  int n = 0;
        

        public  void dosyadanOku()
        {
            // Latlong verisi için değiştiriceğimiz dosya yolu
            string dosya_yolu = @"C:/Users/emre/Downloads/20081027113404.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);//Okuma işlemi için bir StreamReader nesnesi oluşturduk.
            string yazi = sw.ReadLine();
            string[] parcalar;
            bool t = true;
            while (yazi != null && t)
            {
                parcalar = yazi.Split(',');
               // agac.ekle(Convert.ToDouble(parcalar[0]), Convert.ToDouble(parcalar[1]));
                    if (n == 0)
                    {
                        merkez = "{ lat: " + parcalar[0] + " , lng: " + parcalar[1] + "}";
                    }

son = son.ToString() + "{ lat: " + parcalar[0] + " , lng: " + parcalar[1] + ", name: 'Station"+n.ToString()+"' },";

                n++;// kaç tane adres var
                    yazi = sw.ReadLine();
                if (yazi == "")
                    t = false;

            }
            sw.Close();
            fs.Close();
        }



        // WebBrowser web;
        public static Label lbl = new Label(); // html dosyası için oluşturdum

        public void htmlyol() {
            string[] v = { "viewport" , "initial-scale=1.0, user-scalable=no" , "utf-8" ,"map"};
            string api = "https://maps.googleapis.com/maps/api/js?key=AIzaSyCj9rCNsps6A6WllbD2LSuKWebvCN6XNqw&callback=initMap";
            
            lbl.Text= "<!DOCTYPE html>\n" +
 "<html>\n" +
   "<head>\n" +
     "<meta name=" + '"' + "" + v[0] + "" + '"' + " content= " + '"' + "" + v[1] + "" + '"' + " >\n" +
       " <meta charset=" + '"' + "" + v[2] + "" + '"' + " >\n" +
         "<title> Emre Buyukada - Emre Isleyen </title>\n" +
            "<style>\n" +
            " html, body { height: 100%; margin: 0; padding: 0; }\n"+
      "#map {height: 100%;float: left;width: 100%;height: 100%;}\n" +
    "</style>\n"+
  "</head>\n"+
  "<body>\n"+
    "<div id= " + '"' + "" + v[3] + "" + '"' + " ></div>\n" +
    "<script>\n"+
     " function initMap() {\n"+
                "var map = new google.maps.Map(document.getElementById('map'), { \n"+
         " zoom: 4,\n"+
          "center: " + merkez + "\n" +
            "});\n"+
           " var service = new google.maps.DirectionsService; \n"+

           " var stations = [ "+son+" \n"+
             "]; \n"+
" var lngs = stations.map(function(station) { return station.lng; }); var lats = stations.map(function(station) { return station.lat; });\n"+
"map.fitBounds({ west: Math.min.apply(null, lngs),east: Math.max.apply(null, lngs),north: Math.min.apply(null, lats),south: Math.max.apply(null, lats),});\n"+
"for (var i = 0; i < stations.length; i++) { new google.maps.Marker({ position: stations[i], map: map, title: stations[i].name }); }\n"+
"for (var i = 0, parts = [], max = 25 - 1; i<stations.length; i = i + max)	parts.push(stations.slice(i, i + max + 1));\n"+
"var service_callback = function(response, status) {if (status != 'OK') {console.log('Directions request failed due to ' + status);return;}\n"+
"var renderer = new google.maps.DirectionsRenderer; renderer.setMap(map);renderer.setOptions({ suppressMarkers: true, preserveViewport: true });renderer.setDirections(response);};\n"+
"for (var i = 0; i<parts.length; i++) {var waypoints = [];for (var j = 1; j<parts[i].length - 1; j++)waypoints.push({location: parts[i][j], stopover: false});\n"+
"var service_options = { origin: parts[i][0], destination: parts[i][parts[i].length - 1], waypoints: waypoints, travelMode: 'WALKING' }; service.route(service_options, service_callback);}}\n"+
   " </script>\n"+
    "<script async defer \n"+
    " src =" + '"' + "" + api + "" + '"' + ">\n" +
   "</script>\n"+
 " </body>\n"+
 "</html>\n";
        }

        private static void dosyayaYaz()
        {
            string dosya_yolu = @"C:\emre.html";
            if (File.Exists(@"C:\emre.html")) { File.Delete(dosya_yolu); } //Var olan dosyayı silip tekrar yüklüyorizki guncel olsun
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(lbl.Text);
            sw.Flush();
            sw.Close();
            fs.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dosya_yolu = @"C:/indirgeme.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);//Okuma işlemi için bir StreamReader nesnesi oluşturduk.

            string yazi = sw.ReadLine();
            string[] parcalar;


            int kontrol = 0;

            son = "";
            int noktasay = 0;
            bool t = true;
            while (yazi != null && t )
            {
                
                parcalar = yazi.Split(',');
        
               
                if (kontrol == 0 || kontrol==1)
                {
                    if(kontrol==0)
                    sonuc.Text = yazi;
                    if(kontrol==1) //sure
                    {
                        double sure = Convert.ToDouble(yazi);
                        double sure1 = sure / 1000;
                        label6.Text = sure1.ToString();
                    }
                    if(kontrol==2)
                        merkez = "{ lat: " + parcalar[0] + " , lng: " + parcalar[1] + "}";
                }
                 if(kontrol>=2)
                {
                    noktasay++;
son = son.ToString() + "{ lat: " + parcalar[0] + " , lng: " + parcalar[1] + ", name: 'Station " + noktasay.ToString() + "' },";
                }
                kontrol++;
                yazi = sw.ReadLine();
                if (yazi == "")
                    t = false;
               
            }
            sw.Close();
            fs.Close();


            htmlyol();

            dosyayaYaz();

            kontrol =kontrol - 1;
            chrome = new ChromiumWebBrowser("file:///C:/emre.html");
            this.panel2.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            label4.Text = "  " + noktasay.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client Yeni = new Client();
            Yeni.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {    
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dosyadanOku();
            
            htmlyol();
          
            dosyayaYaz();
            MessageBox.Show("Doyaya yaz bitti");
            
            

           
            chrome = new ChromiumWebBrowser("file:///C:/emre.html");
            this.panel1.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            label2.Text = "  "+n.ToString();

        }
    }
}