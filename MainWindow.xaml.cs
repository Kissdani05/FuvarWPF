using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<Fuvar> lista = new List<Fuvar>();
            using (StreamReader sr = new StreamReader("fuvar.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Fuvar sor2 = new Fuvar(sor);
                    lista.Add(sor2);
                }
            }
            
            MessageBox.Show(Convert.ToString("3. feladat: "+ lista.Count()+" fuvar"));
            int Fuvarszam = 0;
            double osszBevetel = 0;
            foreach (var sorok in lista.Where(x=>x.TaxiId==6185))
            {
                Fuvarszam++;
                osszBevetel += sorok.Viteldij + sorok.Borravalo;
            }
            MessageBox.Show(Convert.ToString("4. feladat: " + Fuvarszam +" fuvar alatt: "+ osszBevetel + "$"));
            MessageBox.Show(Convert.ToString("5. feladat: "+"\n bankkártya: " +lista.Count(x=>x.Fizetes_modja=="bankkártya")+ " fuvar" + "\n Készpénz: " + lista.Count(x => x.Fizetes_modja == "készpénz") + " fuvar" + "\n Vitatott:" + lista.Count(x => x.Fizetes_modja == "vitatott") + " fuvar" + "\n Ingyenes:" + lista.Count(x => x.Fizetes_modja == "ingyenes") + " fuvar" + "\n Ismeretlen:" + lista.Count(x => x.Fizetes_modja == "ismeretlen") + " fuvar"));
            double merfold = 0;
            foreach (var sorok in lista)
            {
                merfold += sorok.Tavolsag;
            }
            double kilometer = merfold * 1.6;
            MessageBox.Show(Convert.ToString("6. feladat: " + Math.Round(kilometer, 2) + " km"));
            
            
            lista.OrderByDescending(x=>x.Indulas).ThenByDescending(x=>x.Indulas).ToList();
            
            using(StreamWriter outputFile = new StreamWriter("hibak.txt"))
            {
                foreach (var sor in lista) 
                {
                    outputFile.WriteLine(sor);
                }
            }
        }
    }
}
