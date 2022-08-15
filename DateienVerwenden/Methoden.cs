using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DateienVerwenden
{
    //eine Klasse als Container
    //es soll kein objekt davon erzeugt werden können
    //alles was in dieser klasse definiert wird, muss static sein
    static class Methoden
    {
        //methode für schreiben in eine textdatei
        public static void SchreibenDatei()
        {
            //pfad suchen für Dokumentenordner
            String pfad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //wir ersetllen einen ordner
            Directory.CreateDirectory(pfad + "/ordner");
            pfad = pfad + "/ordner/datei1.txt";

            //prüfen ob es die Datei schon gibt
            if (File.Exists(pfad) == false)
            {
                //eine Zeile in eine datei schreiben
                File.WriteAllText(pfad, "Hallo Welt \nlol \n");
            }
            else
            {
                Console.WriteLine("gibt es schon");
            }
        }

        public static void AnhängenDatei()
        {
            //pfad suchen für Dokumentenordner
            String pfad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //wir ersetllen einen ordner
            Directory.CreateDirectory(pfad + "/ordner");
            pfad = pfad + "/ordner/datei2.txt";

            //wir erstellen eine Liste mit Zeilen, die in die Datei geschrieben werden sollen
            List<string> inhalt = new List<string>();

            inhalt.Add("1;Hose;23,45;10");
            inhalt.Add("2;Hemd;19,99;15");
            inhalt.Add("3;Socken;5,99;20");

            //Liste in Datei schreiben
            File.AppendAllLines(pfad, inhalt);
        }

        public static void LesenDatei()
        {
            //pfad suchen für Dokumentenordner
            String pfad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //wir ersetllen einen ordner
            Directory.CreateDirectory(pfad + "/ordner");
            pfad = pfad + "/ordner/datei2.txt";

            if(File.Exists(pfad) == false)
            {
                Console.WriteLine("Geh weg");
                return; //wir verlassen die Methode
            }

            string[] zeilen = File.ReadAllLines(pfad);

            foreach(string artikel in zeilen)
            {
                string[] werte = artikel.Split(';');

                //Wert[2] (Preis) ist ein string und muss in eine Zahl geparsed werden um verwendet werden zu können
                double.TryParse(werte[2], out double preis);

                //Nur Artikel kleiner als 20 werden ausgegeben
                if (preis < 20) {
                    Console.WriteLine("ID:" + werte[0]);
                    Console.WriteLine("Bezeichnung:" + werte[1]);
                    Console.WriteLine("Preis:" + werte[2]);
                    Console.WriteLine("Menge:" + werte[3]);
                    Console.WriteLine();
                }

            }
        }
    }
}
